---
title: Gestire le proprietà della presentazione con Python
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/python-net/presentation-properties/
keywords:
- Proprietà PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà integrate
- Proprietà personalizzate
- Proprietà avanzate
- Gestire le proprietà
- Modificare le proprietà
- Metadati del documento
- Modificare i metadati
- Lingua di revisione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci al meglio le proprietà della presentazione in Aspose.Slides per Python tramite .NET e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET supporta le proprietà di documento **integrate** e **personalizzate**. Utilizza queste proprietà per leggere e aggiornare i metadati della presentazione, ad esempio l'autore, il titolo e i valori definiti dall'utente.

Aspose.Slides consente di lavorare con le proprietà di documento della presentazione tramite la classe [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Un'istanza di questa classe è restituita da [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestisce i metadati dell'applicazione e del produttore durante il salvataggio delle presentazioni; questi campi identificano il software che ha creato il risultato.
{{% /alert %}}

## **Gestire le proprietà della presentazione**

Le proprietà del documento conservano informazioni descrittive insieme al contenuto della presentazione. Si dividono in due categorie:

- **Proprietà integrate** contengono metadati standard, come il titolo, l'autore e le statistiche del documento.
- **Proprietà personalizzate** memorizzano coppie nome/valore definite dall'utente.

Aspose.Slides per Python tramite .NET fornisce l'accesso a entrambe le categorie. In PowerPoint, seleziona **File → Info → Proprietà → Proprietà avanzate** per ispezionare i metadati del documento. La finestra di dialogo raggruppa le informazioni in schede come **Riepilogo**, **Statistiche**, **Contenuti** e **Personalizzate**. Usa la scheda **Personalizzate** per gestire le proprietà definite dall'utente.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura protegge normalmente sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittografata con [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) impostato su `False`, le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi impostare [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) su `True` e leggere i metadati pubblici senza fornire la password di apertura.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) controlla cosa carica Aspose.Slides; non decritta nulla. Se le proprietà erano incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione viene ignorata e viene caricata l'intera presentazione.

L'esempio richiede una presentazione crittografata le cui proprietà del documento sono state lasciate pubbliche. Verifica la modalità di caricamento tramite [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) e poi legge le proprietà integrate attraverso [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) prima di eseguire un'operazione che richiede il modello completo degli oggetti della presentazione.

{{% alert color="warning" title="Security" %}}
I metadati pubblici possono esporre i nomi degli autori, i titoli, gli argomenti, le parole chiave, le informazioni aziendali, i commenti e i valori personalizzati. Crittografa le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione documentale hanno una specifica necessità di accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata con [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto contenente solo metadati perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. Per aggiornarle è quindi necessaria la password di apertura corretta e un caricamento completo.

L'esempio richiede una presentazione PPTX crittografata con proprietà del documento pubbliche e una password di apertura nota. Apre la presentazione completa con [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), aggiorna le proprietà integrate pubbliche e salva il risultato. Quindi utilizza [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Se a un'applicazione non è consentito decrittare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come sola lettura.

## **Accedere alle proprietà integrate**

La classe [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) espone i metadati integrati tramite proprietà tipizzate, incluse [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) e [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Questo esempio apre una presentazione esistente e stampa i metadati memorizzati sulla console. I valori dipendono dalla presentazione di input; alcuni campi potrebbero essere vuoti.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Modificare le proprietà integrate**

Per aggiornare i metadati integrati, assegnare valori alle proprietà scrivibili esposte da [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Questo esempio apre una presentazione esistente, imposta [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), e [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), quindi salva la presentazione aggiornata con [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Il PPTX salvato contiene i nuovi metadati.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire la base dei collegamenti ipertestuali**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) memorizza la base a livello di documento per i collegamenti ipertestuali relativi. È utile quando si sposta una presentazione e i relativi file collegati in un'altra posizione. È separata dal [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) di un singolo collegamento ipertestuale: modificare la base non riscrive gli indirizzi dei collegamenti memorizzati né cambia le destinazioni assolute.

L'esempio richiede una presentazione contenente sia un collegamento relativo, ad esempio `target.html`, sia un collegamento assoluto a un file o sito web. Legge la base esistente, assegna un nuovo indirizzo di base, salva e riapre la presentazione per verificare il valore. Quindi cancella la base con `""` e verifica il valore vuoto in un file salvato separato. Sostituisci l'indirizzo di base dell'esempio con la posizione dei tuoi file collegati.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

I due messaggi di verifica dovrebbero stampare `True`. Cancellare la base lascia intatti gli indirizzi dei singoli collegamenti ipertestuali.

Un collegamento relativo a `target.pptx` apriva `old/target.pptx` quando la base puntava alla cartella `old`. Dopo aver cambiato la base nella cartella `new`, salvato e riaperto la presentazione, lo stesso collegamento apriva `new/target.pptx`. Un collegamento assoluto continuava ad aprire lo stesso file. Prova i tuoi collegamenti relativi in PowerPoint prima e dopo aver spostato la presentazione o modificato la sua base.

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate memorizzano metadati che non hanno un campo integrato corrispondente. Il metodo [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) consente di assegnare un valore tramite il nome della proprietà. Questo esempio crea una presentazione, aggiunge due valori di testo e un valore intero di versione, e salva la presentazione con [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Assegnare un valore a un nome già esistente sostituisce il valore di quella proprietà.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere e modificare le proprietà personalizzate**

Questo esempio apre una presentazione contenente proprietà personalizzate e utilizza [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) per iterarle. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) accetta un indice basato su zero e restituisce il nome usato da [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). L'esempio richiede una presentazione le cui proprietà personalizzate siano tutte stringhe. Stampa ogni nome e valore originale, sostituisce ogni valore con una stringa numerata e salva le modifiche. Se non ci sono proprietà personalizzate, il ciclo non apporta modifiche.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) restituisce il valore tramite la lista a un elemento passata come secondo argomento. Il segnaposto deve corrispondere al tipo della proprietà memorizzata: usa `[""]` per una stringa o `[0]` per un intero. Un tipo non corrispondente genera un `InvalidCastException`; scegli il segnaposto in base allo schema delle tue proprietà personalizzate.

## **Esempio live**

Prova l'app online [**Visualizza & Modifica i Metadati PowerPoint**](https://products.aspose.app/slides/metadata) per vedere come lavorare con le proprietà del documento usando l'API Aspose.Slides:

[![Visualizza & Modifica i Metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Domande frequenti**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificare i loro valori o impostarli a vuoto se consentito dalla specifica proprietà.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il valore esistente verrà sovrascritto da quello nuovo. Non è necessario rimuovere o controllare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) e poi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Vedi [Costruire un inventario di presentazioni leggero](/slides/it/python-net/examine-presentation/) per un esempio completo di report e le limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittografata con [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) impostato su `False` e deve essere caricata con [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) impostato su `True`.

**Posso aggiornare un file PPTX crittografato in modalità solo proprietà del documento?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi aggiornare un file PPTX crittografato richiede il caricamento dell'intera presentazione con la password di apertura corretta.