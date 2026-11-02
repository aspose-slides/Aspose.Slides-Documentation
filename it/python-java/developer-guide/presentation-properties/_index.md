---
title: Gestire le proprietà della presentazione in Python
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/python-java/presentation-properties/
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
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- Presentazione
- Python
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Python tramite Java e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per Python tramite Java supporta le proprietà dei documenti **integrate** e **personalizzate**. Utilizza queste proprietà per leggere e aggiornare i metadati della presentazione, ad esempio autore, titolo e valori definiti dall'utente.

Aspose.Slides consente di lavorare con le proprietà dei documenti della presentazione tramite la classe [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/). Un’istanza di questa classe viene restituita da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestisce i metadati dell’applicazione e del produttore durante il salvataggio delle presentazioni; questi campi identificano il software che ha creato il risultato.
{{% /alert %}}

## **Gestire le proprietà della presentazione**

Le proprietà del documento memorizzano informazioni descrittive insieme al contenuto della presentazione. Si suddividono in due categorie:

- **Proprietà integrate** contengono metadati standard, come titolo, autore e statistiche del documento.
- **Proprietà personalizzate** memorizzano coppie nome/valore definite dall’utente.

Aspose.Slides per Python tramite Java fornisce l’accesso a entrambe le categorie. In PowerPoint, seleziona **File → Info → Proprietà → Proprietà avanzate** per esaminare i metadati del documento. La finestra raggruppa le informazioni in schede quali **Riepilogo**, **Statistiche**, **Contenuti** e **Personalizzato**. Usa la scheda **Personalizzato** per gestire le proprietà definite dall’utente.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura protegge normalmente sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione viene crittografata dopo aver chiamato [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `False`, le sue proprietà del documento rimangono pubbliche. Un’applicazione può quindi chiamare [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True` e leggere i metadati pubblici senza fornire la password di apertura.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà erano incluse nella crittografia, il caricamento senza password fallisce. Se la presentazione non è crittografata, l’opzione è ignorata e l’intera presentazione viene caricata.

L’esempio richiede una presentazione crittografata le cui proprietà del documento sono state lasciate pubbliche. Verifica la modalità di caricamento tramite [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e poi legge le proprietà integrate mediante [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prima di eseguire un’operazione che richiede l’intero modello a oggetti della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono esporre nomi di autori, titoli, soggetti, parole‑chiave, informazioni aziendali, commenti e valori personalizzati. Cripta le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione documentale hanno esigenze specifiche per accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True` è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà cambiate da quell’oggetto “solo metadati” perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all’interno della presentazione crittografata. Per aggiornarle è quindi necessario fornire la password di apertura corretta e caricare l’intera presentazione.

L’esempio richiede una presentazione PPTX crittografata con proprietà del documento pubbliche e una password di apertura nota. Apre la presentazione completa con [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), aggiorna le proprietà integrate pubbliche e salva il risultato. Quindi utilizza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) per verificare che la crittografia sia mantenuta e riapre i metadati pubblici senza password per verificare i nuovi valori:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Se un’applicazione non è autorizzata a decrittare o a caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come sola lettura.

## **Accedere alle proprietà integrate**

La classe [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) espone i metadati integrati tramite metodi getter, tra cui [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) e [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Questo esempio apre una presentazione esistente e stampa i metadati memorizzati sulla console. I valori dipendono dalla presentazione di ingresso; alcuni campi possono essere vuoti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Modificare le proprietà integrate**

Per aggiornare i metadati integrati, utilizza i metodi setter sull’oggetto restituito da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Questo esempio apre una presentazione esistente, chiama [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) e [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), quindi salva la presentazione aggiornata con [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Il PPTX salvato contiene i nuovi metadati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gestire la base dei collegamenti ipertestuali**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) restituisce la base a livello di documento per i collegamenti ipertestuali relativi. Usa [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) per modificarla o cancellarla. È utile quando si sposta una presentazione e i suoi file collegati in un’altra posizione. È separata dal metodo [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) di un singolo collegamento: la modifica della base non riscrive gli indirizzi dei collegamenti memorizzati né cambia le destinazioni assolute.

L’esempio richiede una presentazione contenente sia un collegamento relativo, ad es. `target.html`, sia un collegamento assoluto, ad es. `https://example.org/absolute.html`. Legge la base esistente, assegna una nuova base, salva e riapre la presentazione per verificare il valore. Quindi cancella la base impostandola a stringa vuota e verifica il valore vuoto in un file salvato separato. Sostituisci la base di esempio con il percorso dei tuoi file collegati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

I due messaggi di verifica dovrebbero stampare `True`. Cancellare la base mantiene inalterati gli indirizzi dei singoli collegamenti ipertestuali.

Un collegamento relativo a `target.pptx` apriva `old/target.pptx` quando la base puntava alla cartella `old`. Dopo aver cambiato la base nella cartella `new`, salvato e riaperto la presentazione, lo stesso collegamento apriva `new/target.pptx`. Un collegamento assoluto continuava ad aprire lo stesso file. Prova i tuoi collegamenti relativi in PowerPoint prima e dopo aver spostato la presentazione o cambiato la sua base.

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate memorizzano metadati che non hanno un campo integrato corrispondente. Il metodo [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) consente di assegnare un valore tramite il nome della proprietà. Questo esempio crea una presentazione, aggiunge due valori di testo e un valore intero di versione (usando `jpype.JInt` per passare un intero Java) e salva la presentazione con [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Assegnare un valore a un nome esistente sostituisce il valore della proprietà.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedere e modificare le proprietà personalizzate**

Questo esempio apre una presentazione contenente proprietà personalizzate e utilizza [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) per iterarle. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) accetta un indice basato su zero e restituisce il nome usato da [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). L’esempio stampa ogni nome e valore originali, sostituisce ogni valore con una stringa numerata indipendentemente dal tipo originale e salva le modifiche. Se non ci sono proprietà personalizzate, il ciclo non apporta modifiche.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Esempio live**

Prova l’app online [**Visualizza e modifica i metadati PowerPoint**](https://products.aspose.app/slides/metadata) per vedere come lavorare con le proprietà dei documenti usando l’API Aspose.Slides:

[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate fanno parte integrante della presentazione e non possono essere rimosse del tutto. Tuttavia, è possibile modificarne i valori oppure impostarle a vuoto se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata già presente, il valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricarla completamente?**

Sì. Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e poi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadati del documento memorizzati senza creare un’istanza di [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/python-java/examine-presentation/) per un esempio completo di reporting e per le limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittografata dopo aver chiamato [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `False`, e deve essere caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True`.

**Posso aggiornare un file PPTX crittografato in modalità “solo proprietà del documento”?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi aggiornare un file PPTX crittografato richiede il caricamento completo della presentazione con la password di apertura corretta.