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
description: "Scopri come aprire presentazioni PowerPoint e OpenDocument in Python, fornire password di apertura e ridurre l'uso della memoria con Aspose.Slides per Python via .NET."
---
## **Introduzione**

[Aspose.Slides per Python via .NET](https://products.aspose.com/slides/it/python-net/) può caricare presentazioni PowerPoint e OpenDocument da file e flussi. Dopo che una presentazione è stata caricata, è possibile ispezionare la sua struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari fuori dalla memoria o omettere i dati binari incorporati.

## **Aprire le presentazioni**

Per aprire una presentazione esistente, passare il percorso del file al costruttore [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Utilizzare una dichiarazione `with` in modo che i gestori di file, i dati temporanei e le altre risorse vengano rilasciati prontamente.

Il seguente esempio Python mostra come aprire una presentazione e ottenere il conteggio delle diapositive:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Aprire presentazioni protette da password**

Una password di apertura cripta il contenuto della presentazione. Per caricare l'intera presentazione, assegnare la password corretta a [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/) e passare le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Il caricamento fallisce se la password è mancante o errata.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Per i flussi di lavoro di rilevamento, convalida e crittografia delle password, vedere [Protezione con password delle presentazioni](/slides/it/python-net/password-protected-presentation/). Se una presentazione crittografata è stata salvata deliberatamente con proprietà del documento pubbliche, tali proprietà possono essere lette senza password; vedere [Gestire le proprietà della presentazione](/slides/it/python-net/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/blob_management_options/) controlla come Aspose.Slides gestisce i grandi oggetti binari come immagini, audio e video. È possibile mantenere il file di origine bloccato, consentire file temporanei e limitare la quantità di dati BLOB mantenuti in memoria.

Questo codice Python dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Con `PresentationLockingBehavior.KEEP_LOCKED`, il file di origine rimane bloccato fino a quando l'oggetto `Presentation` non viene eliminato. Non spostare, sovrascrivere o eliminare il file di origine mentre quell'oggetto è attivo.

Aspose.Slides può copiare il contenuto di un flusso di input durante il caricamento. Per le presentazioni di grandi dimensioni, un percorso di file è quindi generalmente più efficiente di un flusso. Vedere [Gestire i BLOB](/slides/it/python-net/manage-blob/) per ulteriori opzioni di archiviazione e gestione della memoria.
{{% /alert %}}

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole mantenere. Esempi includono:

- progetti VBA, disponibili tramite [Presentation.vba_project](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/vba_project/);
- dati OLE incorporati, disponibili tramite [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- dati di controllo ActiveX, disponibili tramite [Control.active_x_control_binary](https://reference.aspose.com/slides/it/python-net/aspose.slides/control/active_x_control_binary/).

Impostare [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) su `True` per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per conservare il risultato sanitizzato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanitizzazione dei contenuti.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Come posso capire che un file è corrotto e non può essere aperto?**

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestire tale errore separatamente da un errore di password errata in modo che l'applicazione possa segnalare la causa in modo accurato.

**Cosa succede se i font richiesti sono mancanti?**

La presentazione può ancora essere caricata, ma il rendering e l'esportazione potrebbero sostituire i font. È possibile [configurare la sostituzione dei font](/slides/it/python-net/font-substitution/) o [fornire font personalizzati](/slides/it/python-net/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

Audio e video incorporati diventano disponibili attraverso il modello a oggetti della presentazione. Le risorse esterne vengono risolte secondo il comportamento predefinito di caricamento delle risorse e possono non essere disponibili se le loro posizioni non sono accessibili.