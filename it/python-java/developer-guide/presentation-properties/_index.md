---
title: Gestire le proprietà della presentazione in Python
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/python-java/presentation-properties/
keywords:
- Proprietà di PowerPoint
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
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Python via Java e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per Python via Java supporta le proprietà del documento **integrate** e **personalizzate**. Usa queste proprietà per leggere e aggiornare i metadati della presentazione, come l'autore, il titolo e i valori definiti dall'utente.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione tramite la classe [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/). Un'istanza di questa classe è restituita da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestisce i metadati dell'applicazione e del produttore durante il salvataggio delle presentazioni; questi campi identificano il software che ha creato l'output.
{{% /alert %}}

## **Gestire le proprietà della presentazione**

Le proprietà del documento memorizzano informazioni descrittive accanto al contenuto della presentazione. Rientrano in due categorie:

- **Proprietà integrate** contengono metadati standard, come il titolo, l'autore e le statistiche del documento.
- **Proprietà personalizzate** memorizzano coppie nome/valore definite dall'utente.

Aspose.Slides per Python via Java fornisce l'accesso a entrambe le categorie. In PowerPoint, seleziona **File → Info → Proprietà → Proprietà avanzate** per esaminare i metadati del documento. La finestra raggruppa le informazioni in schede come **Riepilogo**, **Statistiche**, **Contenuti** e **Personalizzate**. Usa la scheda **Personalizzate** per gestire le proprietà definite dall'utente.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione viene crittografata dopo aver chiamato [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `False`, le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi chiamare [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True` e leggere i metadati pubblici senza fornire la password di apertura.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) controlla ciò che Aspose.Slides carica; non decritta nulla. Se le proprietà sono state incluse nella crittografia, il loro caricamento senza la password fallisce. Se la presentazione non è crittografata, l'opzione viene ignorata e viene caricata la presentazione completa.

L'esempio richiede una presentazione crittografata le cui proprietà del documento sono state lasciate pubbliche. Verifica la modalità di caricamento tramite [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e poi legge le proprietà integrate tramite [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):
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

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre controllare [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prima di eseguire un'operazione che richiede il modello completo degli oggetti della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono rivelare nomi degli autori, titoli, argomenti, parole chiave, informazioni aziendali, commenti e valori personalizzati. Cripta le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando la indicizzazione, la classificazione, la ricerca o i sistemi di gestione dei documenti hanno una necessità specifica di accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True` è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto contenente solo metadati perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. Aggiornarle richiede quindi la password di apertura corretta e un caricamento completo.

L'esempio richiede una presentazione PPTX crittografata con proprietà del documento pubbliche e una password di apertura nota. Apre la presentazione completa con [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), aggiorna le proprietà integrate pubbliche e salva il risultato. Quindi utilizza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) per verificare che la crittografia sia mantenuta e riapre i metadati pubblici senza password per verificare i nuovi valori:
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

Se a un'applicazione non è consentito decifrare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come di sola lettura.

## **Accedere alle proprietà integrate**

La classe [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) espone i metadati integrati tramite metodi getter, inclusi [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) e [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Questo esempio apre una presentazione esistente e stampa i metadati memorizzati sulla console. I valori dipendono dalla presentazione di input; alcuni campi potrebbero essere vuoti.
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

### **Segnala il numero di revisione e il tempo di modifica**

Per segnalare una riga per ogni file PPTX nella cartella `presentations`, utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere le sue [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) senza caricare le diapositive per la modifica. L'API Python via Java restituisce la durata della modifica in millisecondi. L'esempio la formatta in ore, minuti e secondi, con un conteggio dei giorni per durate di 24 ore o più.
```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

Per una presentazione con un tempo di modifica registrato di 1 giorno, 2 ore e 5 minuti, il report mostra il seguente output.
```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) legge un valore che le applicazioni possono modificare con [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber). Il numero di revisione da solo non può determinare quante volte la presentazione è stata salvata né ricostruire la sua cronologia delle versioni.

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) legge la durata della modifica registrata nel file. Un valore di `00:00:00` indica che la durata memorizzata è zero, anche se qualcuno ha modificato la presentazione.

## **Modificare le proprietà integrate**

Per aggiornare i metadati integrati, utilizza i metodi setter sull'oggetto restituito da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Questo esempio apre una presentazione esistente, chiama [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) e [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), quindi salva la presentazione aggiornata con [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Il PPTX salvato contiene i nuovi metadati.
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

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) restituisce la base a livello di documento per i collegamenti ipertestuali relativi. Usa [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) per modificarla o cancellarla. È utile quando si sposta una presentazione e i suoi file collegati in un'altra posizione. È separata dal [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) di un singolo collegamento ipertestuale: modificare la base non riscrive gli indirizzi dei collegamenti memorizzati né cambia le destinazioni assolute.

L'esempio richiede una presentazione contenente sia un collegamento relativo, ad esempio `target.html`, sia un collegamento assoluto, ad esempio `https://example.org/absolute.html`. Legge la base esistente, assegna un nuovo indirizzo di base e salva e riapre la presentazione per verificare il valore. Quindi cancella la base con una stringa vuota e verifica il valore vuoto in un file salvato separato. Sostituisci l'indirizzo di base dell'esempio con la posizione dei tuoi file collegati.
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

I due messaggi di verifica dovrebbero stampare `True`. Cancellare la base lascia intatti gli indirizzi dei singoli collegamenti ipertestuali.

Un collegamento relativo a `target.pptx` apriva `old/target.pptx` quando la base puntava alla cartella `old`. Dopo aver cambiato la base nella cartella `new`, salvato e riaperto la presentazione, lo stesso collegamento apriva `new/target.pptx`. Un collegamento assoluto ha continuato ad aprire lo stesso file. Prova i tuoi collegamenti relativi in PowerPoint prima e dopo aver spostato la presentazione o cambiato la sua base.

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate memorizzano metadati che non hanno un campo integrato corrispondente. Il metodo [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) consente di assegnare un valore per nome di proprietà. Questo esempio crea una presentazione, aggiunge due valori di testo e un valore intero di versione (usando `jpype.JInt` per passare un intero Java), e salva la presentazione con [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Assegnare un valore a un nome esistente sostituisce il valore di quella proprietà.
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

Questo esempio apre una presentazione contenente proprietà personalizzate e utilizza [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) per iterarle. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) accetta un indice a base zero e restituisce il nome usato da [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). L'esempio stampa ogni nome e valore originale, sostituisce ogni valore con una stringa numerata indipendentemente dal tipo originale e salva le modifiche. Se non ci sono proprietà personalizzate, il ciclo non apporta modifiche.
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

Prova l'app online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) per vedere come lavorare con le proprietà del documento usando l'API Aspose.Slides:
[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile cambiare i loro valori o impostarli a vuoto se consentito dalla specifica proprietà.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e poi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/python-java/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittografata dopo aver chiamato [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) con `False`, e deve essere caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) con `True`.

**Posso aggiornare un file PPTX crittografato in modalità solo proprietà del documento?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento completo della presentazione con la password di apertura corretta.