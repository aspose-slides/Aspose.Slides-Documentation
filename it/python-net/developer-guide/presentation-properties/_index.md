---
title: Gestire le proprietà della presentazione con Python
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/python-net/presentation-properties/
keywords:
- Proprietà PowerPoint
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
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Python via .NET e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà dei documenti: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti della presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/). Un'istanza di questa classe viene restituita dalla proprietà [Presentation.document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/document_properties/). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Nota" %}}
Si prega di notare che non è possibile impostare valori sui campi **Application** e **Producer**, poiché Aspose Ltd. e Aspose.Slides for Python via .NET x.x.x verranno visualizzati su questi campi.
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà dei documenti consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà dei documenti come segue

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for Python via .NET, developers can access and modify the values of built-in properties as well as custom properties. Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007. After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file. In the **Properties Dialog**, you can see that there are many tab pages like **General, Summary, Statistics, Contents and Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage the custom properties of the PowerPoint files.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

An opening password normally protects both presentation content and document properties. When a presentation is encrypted with [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) set to `False`, its document properties remain public. An application can then set [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/only_load_document_properties/) to `True` and read the public metadata without supplying the opening password.

`only_load_document_properties` controls what Aspose.Slides loads; it does not decrypt anything. If the properties were included in encryption, loading them without the password fails. If the presentation is not encrypted, the option is ignored and the complete presentation is loaded.

The following example verifies the loading mode through [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) and then reads built-in properties through [Presentation.document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

In this mode, slide content is not loaded. Slides, masters, layouts, shapes, media, and other presentation objects are unavailable. Applications should always check `is_only_document_properties_loaded` before performing an operation that requires the complete presentation object model.

{{% alert color="warning" title="Sicurezza" %}}
Public metadata may expose author names, titles, subjects, keywords, company information, comments, and custom values. Encrypt sensitive properties together with the presentation. Leave them public only when indexing, classification, search, or document-management systems have a specific requirement to access them without a password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

For an encrypted PPTX file, a presentation loaded with `only_load_document_properties` is intended for reading public metadata. Aspose.Slides cannot save changed properties from that metadata-only object because the public properties must remain consistent with the corresponding data inside the encrypted presentation. Updating them therefore requires the correct opening password and a complete load.

The following example opens the presentation with [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/), updates public built-in properties, and saves the result. It then uses [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/is_encrypted/) to verify that encryption is preserved and reopens the public metadata without a password to verify the new values:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
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

If an application is not allowed to decrypt or load the presentation content, it must treat public properties of an encrypted PPTX file as read-only.

## **Accedere alle proprietà Built-in**

These properties as exposed by **IDocumentProperties** object include: **Creator(Author)**, **Description**, **Keywords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**
```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta la presentazione
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Creare un riferimento all'oggetto associato a Presentation
    documentProperties = pres.document_properties

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

## **Modificare le proprietà Built-in**

Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated that how we can modify the built-in document properties of the presentation file.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta la Presentazione
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Creare un riferimento all'oggetto associato a Presentation
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

Aspose.Slides for Python via .NET also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

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

    # Ottenere il nome della proprietà a un indice specifico
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Rimuovere la proprietà selezionata
    documentProperties.remove_custom_property(getPropertyName)

    # Salvare la presentazione
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides for Python via .NET also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta il PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Creare un riferimento all'oggetto document_properties associato a Presentation
    documentProperties = presentation.document_properties

    # Accedere e modificare le proprietà personalizzate
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Visualizzare i nomi e i valori delle proprietà personalizzate
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modificare i valori delle proprietà personalizzate
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # salvare la presentazione in un file
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` returns the value through the one-element list passed as its second argument, and the stored value is cast to the type of the element already in that list. The example above uses `[""]`, so it reads string properties; to read a property stored as a number, pass a numeric placeholder such as `[0]`—otherwise the call raises an `InvalidCastException`.

## **Impostare la lingua di correzione**

Aspose.Slides provides the `Language_Id` property (exposed by the [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/) class) to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spellings and grammar in the PowerPoint are checked.

This Python code shows you how to set the proofing language for a PowerPoint:

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

    # impostare l'Id di una lingua di correzione
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Impostare la lingua predefinita**

This Python code shows you how to set the default language for an entire PowerPoint presentation:

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

## **Esempio dal vivo**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà dei documenti tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes. Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) and then [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) instance. See [Build a Lightweight Presentation Inventory](/slides/it/python-net/examine-presentation/) for a complete reporting example and format-specific limitations.

**Can I read public properties of an encrypted presentation without its opening password?**

Yes. The presentation must have been encrypted with `encrypt_document_properties` set to `False`, and it must be loaded with `only_load_document_properties` set to `True`.

**Can I update an encrypted PPTX file in document-properties-only mode?**

No. Public and encrypted property data must remain consistent, so updating an encrypted PPTX file requires loading the complete presentation with the correct opening password.