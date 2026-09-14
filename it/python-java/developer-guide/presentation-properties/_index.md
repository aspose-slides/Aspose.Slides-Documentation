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
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Python via Java e ottimizza la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/). Un'istanza di questa classe viene restituita da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getDocumentProperties). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Nota" %}}
Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li riscrive a ogni salvataggio, quindi una presentazione salvata riporta sempre "Aspose.Slides for Java" e la versione della libreria che l'ha generata. Qualsiasi valore passato a [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#setNameOfApplication) viene scartato quando la presentazione viene scritta.
{{% /alert %}}

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Fare clic sull'icona Office e selezionare **Prepare | Properties | Advanced Properties**, come mostrato di seguito:

|**Selezione voce di menu Proprietà avanzate**|
| :- |
|![Proprietà del documento PowerPoint](https://i.imgur.com/ZrmuCD6.jpg)|
Dopo aver selezionato **Advanced Properties**, appare una finestra di dialogo in cui è possibile gestire le proprietà del documento del file PowerPoint:

|**Finestra Proprietà**|
| :- |
|![Proprietà del documento PowerPoint](https://i.imgur.com/LibmdQd.jpg)|
La **Finestra Proprietà** contiene schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Queste schede consentono di configurare diversi tipi di informazioni sui file PowerPoint. Utilizzare la scheda **Custom** per gestire le proprietà personalizzate.

## **Lavorare con le proprietà del documento usando Aspose.Slides per Python via Java**

Come descritto in precedenza, Aspose.Slides per Python via Java supporta sia le proprietà **Built-in** sia le **Custom** del documento. La classe [DocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/) rappresenta le proprietà del documento associate a un file di presentazione.

Utilizzare [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getDocumentProperties) per accedere a queste proprietà come descritto di seguito.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura protegge normalmente sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittografata passando `false` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi passare `true` a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) e leggere i metadati pubblici senza fornire la password di apertura.

L'opzione document-properties-only controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà fossero incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione è ignorata e l'intera presentazione viene caricata.

L'esempio seguente verifica la modalità di caricamento tramite [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e quindi legge le proprietà built-in tramite [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getDocumentProperties):

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

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prima di eseguire un'operazione che richiede il modello completo degli oggetti della presentazione.

{{% alert color="warning" title="Attenzione" %}}
I metadati pubblici possono esporre nomi degli autori, titoli, argomenti, parole chiave, informazioni aziendali, commenti e valori personalizzati. Crittografare le proprietà sensibili insieme alla presentazione. Lasciarle pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione documentale hanno requisiti specifici per accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata in modalità document-properties-only è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto "solo metadati" perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. Pertanto l'aggiornamento richiede la password di apertura corretta e un caricamento completo.

L'esempio seguente apre la presentazione con [LoadOptions.setPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setPassword), aggiorna le proprietà built-in pubbliche e salva il risultato. Poi utilizza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#isEncrypted) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

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

Se un'applicazione non è autorizzata a decrittare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come sola lettura.

## **Accedere alle proprietà Built-in**

Le proprietà built-in esposte da [DocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/) includono: **Creator** (Author), **Description**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** e **Title**.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Istanzia la classe Presentation che rappresenta la presentazione
presentation = Presentation("Presentation.pptx")
try:
    # Crea un riferimento all'oggetto DocumentProperties associato alla Presentazione
    properties = presentation.getDocumentProperties()

    # Visualizza le proprietà integrate
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in è semplice come accedervi. Utilizzare il setter corrispondente per assegnare un nuovo valore. L'esempio seguente modifica le proprietà del documento built-in usando Aspose.Slides per Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Crea un riferimento all'oggetto DocumentProperties associato alla Presentazione
    properties = presentation.getDocumentProperties()

    # Imposta le proprietà integrate
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Salva la presentazione in un file
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questo esempio modifica le proprietà built-in della presentazione, come mostrato di seguito:

|**Proprietà del documento Built-in dopo la modifica**|
| :- |
|![Proprietà del documento PowerPoint](https://i.imgur.com/zz1N9de.jpg)|

## **Aggiungere proprietà del documento personalizzate**

Aspose.Slides per Python via Java consente anche agli sviluppatori di aggiungere proprietà del documento personalizzate alle presentazioni. L'esempio qui sotto aggiunge tre proprietà personalizzate, quindi cerca il nome memorizzato all'indice 2 e rimuove quella proprietà, così la presentazione salvata ne mantiene due. Le proprietà personalizzate sono indicizzate in ordine alfabetico, non nell'ordine di aggiunta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ottenere le proprietà del documento
    properties = presentation.getDocumentProperties()

    # Aggiungere proprietà personalizzate
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Ottenere il nome della proprietà a un indice specifico
    property_name = properties.getCustomPropertyName(2)

    # Rimuovere la proprietà selezionata
    properties.removeCustomProperty(property_name)

    # Salvare la presentazione
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Proprietà del documento personalizzate aggiunte**|
| :- |
|![Proprietà del documento PowerPoint](https://i.imgur.com/HdKcxI9.png)|

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides per Python via Java consente anche agli sviluppatori di accedere ai valori delle proprietà personalizzate. L'esempio seguente mostra come accedere e modificare tutte le proprietà personalizzate in una presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Crea un riferimento all'oggetto DocumentProperties associato alla Presentazione
    properties = presentation.getDocumentProperties()

    # Accedi e modifica le proprietà personalizzate
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Visualizza nomi e valori delle proprietà personalizzate
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Modifica i valori delle proprietà personalizzate
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Salva la tua presentazione in un file
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questo esempio modifica le proprietà personalizzate della presentazione [PPTX](https://docs.fileformat.com/presentation/pptx/). Le figure seguenti mostrano le proprietà personalizzate della presentazione prima e dopo la modifica:

|**Proprietà personalizzate prima della modifica**|
| :- |
|![Proprietà del documento PowerPoint](https://i.imgur.com/Ze7YHvi.jpg)|

|**Proprietà personalizzate dopo la modifica**|
| :- |
|![Proprietà del documento PowerPoint](https://i.imgur.com/Tofu0CL.jpg)|

## **Proprietà avanzate del documento**

{{% alert color="info" title="Nota" %}}
Sono stati aggiunti i nuovi metodi [readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) alla classe [PresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/), e il comportamento del metodo [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#setLastSavedTime) è cambiato.
{{% /alert %}}

I due nuovi metodi [readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) sono stati aggiunti alla classe [PresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/). Forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare l'intera presentazione.

Il tipico flusso di lavoro di caricamento delle proprietà, modifica dei loro valori e aggiornamento del documento può essere implementato come segue:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Leggi le informazioni della presentazione
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Ottieni le proprietà correnti
properties = presentation_info.readDocumentProperties()

# Imposta i nuovi valori dei campi Autore e Titolo
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Aggiorna la presentazione con i nuovi valori
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Esiste un altro modo per utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

È possibile creare un nuovo modello da zero e poi usarlo per aggiornare più presentazioni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Impostare la lingua di correzione**

Aspose.Slides fornisce il metodo [PortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#setLanguageId) per impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale ortografia e grammatica nella presentazione vengono verificate.

Questo codice Python mostra come impostare la lingua di correzione per un PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # imposta l'Id di una lingua di correzione

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Impostare la lingua predefinita**

Questo codice Python mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Aggiunge una forma rettangolare con testo
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Controlla la lingua della prima porzione
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà Built-in da una presentazione?**

Le proprietà built-in sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto se la proprietà specifica lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Utilizzare [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e poi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/python-java/examine-presentation/) per un esempio completo di reporting e limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la password di apertura?**

Sì. La crittografia delle proprietà del documento deve essere stata disabilitata prima che la presentazione venisse crittografata, e la presentazione deve essere caricata in modalità document-properties-only.

**Posso aggiornare un file PPTX crittografato in modalità document-properties-only?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento completo della presentazione con la password di apertura corretta.