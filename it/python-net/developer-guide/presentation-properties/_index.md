---
title: Gestire le proprietà della presentazione con Python
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/python-net/presentation-properties/
keywords:
- proprietà PowerPoint
- proprietà della presentazione
- proprietà del documento
- proprietà integrate
- proprietà personalizzate
- proprietà avanzate
- gestire le proprietà
- modificare le proprietà
- metadati del documento
- modificare i metadati
- lingua di correzione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Python via .NET e semplifica ricerca, branding e flusso di lavoro nei tuoi file PowerPoint."
---
## **Introduzione**

Aspose.Slides supporta due tipologie di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente accessi e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/). Un'istanza di questa classe viene restituita dalla proprietà [Presentation.document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/document_properties/). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="primary" %}} 
Si noti che non è possibile impostare valori nei campi **Application** e **Producer**, poiché Aspose Ltd. e Aspose.Slides for Python via .NET x.x.x verranno visualizzati in questi campi.
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà del documento:

- Proprietà di sistema (Integrate)
- Proprietà utente (Personalizzate)

Le proprietà **Integrate** contengono informazioni generali sul documento, come titolo, nome dell'autore, statistiche del documento e così via. Le proprietà **Personalizzate** sono quelle definite dagli utenti come coppie **Nome/Valore**, dove sia il nome sia il valore sono stabiliti dall'utente. Utilizzando Aspose.Slides for Python via .NET, gli sviluppatori possono accedere e modificare i valori delle proprietà integrate così come di quelle personalizzate. Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Basta fare clic sull'icona Office e quindi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007. Dopo aver selezionato **Advanced Properties**, apparirà una finestra di dialogo che permette di gestire le proprietà del documento del file PowerPoint. Nella **Properties Dialog**, è possibile vedere diverse schede come **General, Summary, Statistics, Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è usata per gestire le proprietà personalizzate dei file PowerPoint.

## **Accedere alle proprietà integrate**
Queste proprietà esposte dall'oggetto **IDocumentProperties** includono: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**
```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta la presentazione
    # Creare un riferimento all'oggetto associato alla Presentazione
    # Visualizzare le proprietà integrate
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

## **Modificare le proprietà integrate**

Modificare le proprietà integrate dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell'esempio riportato di seguito, dimostriamo come modificare le proprietà di documento integrate del file di presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta la presentazione
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Creare un riferimento all'oggetto associato alla Presentation
    documentProperties = presentation.document_properties

    # Impostare le proprietà integrate
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # salva la tua presentazione in un file
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere proprietà personalizzate alla presentazione**

Aspose.Slides for Python via .NET consente anche agli sviluppatori di aggiungere valori personalizzati alle proprietà del documento della presentazione. Un esempio è fornito di seguito che mostra come impostare le proprietà personalizzate per una presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation
with slides.Presentation() as presentation:
    # Ottenere le proprietà del documento
    documentProperties = presentation.document_properties

    # Aggiungere proprietà personalizzate
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Ottenere il nome della proprietà a un indice particolare
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Rimuovere la proprietà selezionata
    documentProperties.remove_custom_property(getPropertyName)

    # Salvare la presentazione
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides for Python via .NET consente inoltre agli sviluppatori di accedere ai valori delle proprietà personalizzate. Un esempio è fornito di seguito che mostra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta il PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Creare un riferimento all'oggetto document_properties associato alla Presentazione
    documentProperties = presentation.document_properties

    # Accedere e modificare le proprietà personalizzate
    for i in range(documentProperties.count_of_custom_properties):
        # Visualizzare i nomi e i valori delle proprietà personalizzate
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modificare i valori delle proprietà personalizzate
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # salvare la presentazione in un file
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà `Language_Id` (esposta dalla classe [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/)) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale vengono controllate ortografia e grammatica in PowerPoint.

Questo codice Python mostra come impostare la lingua di correzione per un PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
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

## **Impostare la lingua predefinita**

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

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà dei documenti tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificare i loro valori o impostarli a vuoto, se consentito dalla specifica proprietà.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il suo valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì, è possibile accedere alle proprietà della presentazione senza caricarla completamente utilizzando il metodo [get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) della classe [PresentationFactory](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/). Quindi, utilizza il metodo [read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/) fornito dalla classe [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.