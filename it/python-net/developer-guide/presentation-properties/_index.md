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
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Python via .NET e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi questi tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione tramite la classe [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/). Un'istanza di questa classe è restituita dalla proprietà [Presentation.document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/document_properties/). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Nota" %}}
Si noti che non è possibile impostare valori per i campi **Application** e **Producer**, poiché Aspose Ltd. e Aspose.Slides for Python via .NET x.x.x verranno visualizzati in questi campi.
{{% /alert %}} 

## **Gestire le Proprietà della Presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipi di proprietà del documento come segue

- Proprietà di Sistema (Integrate)
- Proprietà Definite dall'Utente (Personalizzate)

Le proprietà **Integrate** contengono informazioni generali sul documento, come titolo del documento, nome dell'autore, statistiche del documento e così via. Le proprietà **Personalizzate** sono quelle definite dagli utenti come coppie **Nome/Valore**, dove sia il nome sia il valore sono definiti dall'utente. Utilizzando Aspose.Slides for Python via .NET, gli sviluppatori possono accedere e modificare i valori delle proprietà integrate così come di quelle personalizzate. Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. È sufficiente fare clic sull'icona Office e quindi sull'elemento di menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007. Dopo aver selezionato l'elemento di menu **Advanced Properties**, verrà visualizzata una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint. Nella **Finestra di dialogo Proprietà**, puoi vedere che ci sono molte schede come **Generale, Sommario, Statistiche, Contenuti e Personalizzate**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Personalizzate** è usata per gestire le proprietà personalizzate dei file PowerPoint.

## **Accedere alle Proprietà Integrate**
Queste proprietà esposte dall'oggetto **IDocumentProperties** includono: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**
```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta la presentazione
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Crea un riferimento all'oggetto associato alla Presentation
    documentProperties = pres.document_properties

    # Visualizza le proprietà integrate
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Modificare le Proprietà Integrate**

Modificare le proprietà integrate dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio riportato di seguito, dimostriamo come è possibile modificare le proprietà integrate del documento della presentazione.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta la Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Crea un riferimento all'oggetto associato alla Presentation
    documentProperties = presentation.document_properties

    # Imposta le proprietà integrate
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Salva la tua presentazione in un file
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere Proprietà Personalizzate alla Presentazione**

Aspose.Slides for Python via .NET consente anche agli sviluppatori di aggiungere i valori personalizzati per le proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà personalizzate per una presentazione.

```py
import aspose.slides as slides

# Instanzia la classe Presentation
with slides.Presentation() as presentation:
    # Ottenere le proprietà del documento
    documentProperties = presentation.document_properties

    # Aggiungere proprietà personalizzate
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Ottenere il nome della proprietà a un indice specifico
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Rimuovere la proprietà selezionata
    documentProperties.remove_custom_property(getPropertyName)

    # Salvare la presentazione
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere e Modificare le Proprietà Personalizzate**

Aspose.Slides for Python via .NET consente anche agli sviluppatori di accedere ai valori delle proprietà personalizzate. Di seguito è riportato un esempio che mostra come è possibile accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta il PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Crea un riferimento all'oggetto document_properties associato alla Presentation
    documentProperties = presentation.document_properties

    # Accedi e modifica le proprietà personalizzate
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Visualizza i nomi e i valori delle proprietà personalizzate
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modifica i valori delle proprietà personalizzate
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # salva la tua presentazione in un file
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` restituisce il valore tramite la lista a un elemento passata come secondo argomento, e il valore memorizzato viene convertito al tipo dell'elemento già presente in quella lista. L'esempio sopra usa `[""]`, quindi legge le proprietà stringa; per leggere una proprietà memorizzata come numero, passa un segnaposto numerico come `[0]`—altrimenti la chiamata genera un `InvalidCastException`.

## **Impostare la Lingua di Correzione**

Aspose.Slides fornisce la proprietà `Language_Id` (esposta dalla classe [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/)) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale ortografia e grammatica nel PowerPoint vengono verificate.

Questo codice Python mostra come impostare la lingua di correzione per un PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # imposta l'Id di una lingua di correzione
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Impostare la Lingua Predefinita**

Questo codice Python mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Esempio Live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![Visualizza e Modifica Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate fanno parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile cambiarne i valori o impostarle su vuoto, se consentito dalla proprietà specifica.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se si aggiunge una proprietà personalizzata che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) e poi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/python-net/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche del formato.