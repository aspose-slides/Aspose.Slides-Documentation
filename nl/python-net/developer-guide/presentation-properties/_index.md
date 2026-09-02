---
title: Beheer presentatie‑eigenschappen met Python
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/python-net/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatieweigenschappen in Aspose.Slides voor Python via .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee typen documenteigenschappen: **Built-in** en **Custom**. Beide type eigenschappen kunnen eenvoudig worden benaderd en beheerd met de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/)‑klasse. Een instantie van deze klasse wordt geretourneerd via de eigenschap [Presentation.document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/document_properties/). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Let op dat u geen waarden kunt instellen voor de velden **Application** en **Producer**, omdat Aspose Ltd. en Aspose.Slides for Python via .NET x.x.x in deze velden worden weergegeven.
{{% /alert %}} 

## **Beheer presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan presentatie‑bestanden toe te voegen. Deze documenteigenschappen maken het mogelijk om nuttige informatie samen met de documenten (presentatie‑bestanden) op te slaan. Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (Built-in) eigenschappen
- Gebruiker‑gedefinieerde (Custom) eigenschappen

**Built-in**‑eigenschappen bevatten algemene informatie over het document, zoals de dokumenttitel, de naam van de auteur, documentstatistieken enzovoort. **Custom**‑eigenschappen zijn diegenen die door gebruikers worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden bepaald. Met Aspose.Slides for Python via .NET kunnen ontwikkelaars de waarden van zowel built‑in‑eigenschappen als custom‑eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatie‑bestanden te beheren. Het enige wat u hoeft te doen is op het Office‑pictogram klikken en vervolgens **Prepare | Properties | Advanced Properties** te kiezen in Microsoft PowerPoint 2007. Nadat u **Advanced Properties** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren. In het **Properties Dialog** ziet u verschillende tabbladen zoals **General, Summary, Statistics, Contents and Custom**. Al deze tabbladen maken het configureren van verschillende soorten informatie over de PowerPoint‑bestanden mogelijk. Het **Custom**‑tabblad wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Toegang tot ingebouwde eigenschappen**
Deze eigenschappen, zoals blootgelegd door het **IDocumentProperties**‑object, omvatten: **Creator(Author)**, **Description**, **Keywords**, **Created** (aanmaakdatum), **Modified** (wijzigingsdatum), **Printed** (laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (wordt gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**
```py
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse die de presentatie vertegenwoordigt
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Maak een verwijzing naar het object dat aan de Presentation is gekoppeld
    documentProperties = pres.document_properties

    # Toon de ingebouwde eigenschappen
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

## **Wijzigen van ingebouwde eigenschappen**
Het wijzigen van de ingebouwde eigenschappen van presentatie‑bestanden is even eenvoudig als het benaderen ervan. U kunt eenvoudig een tekenreekswaarde toewijzen aan een gewenste eigenschap en de waarde van die eigenschap wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van het presentatie‑bestand kunnen wijzigen.
```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die de presentatie vertegenwoordigt
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Maak een verwijzing naar het object dat aan de Presentation is gekoppeld
    documentProperties = presentation.document_properties

    # Stel de ingebouwde eigenschappen in
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Sla uw presentatie op naar een bestand
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste presentatie‑eigenschappen toevoegen**
Aspose.Slides for Python via .NET stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe u de aangepaste eigenschappen voor een presentatie kunt instellen.
```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse
with slides.Presentation() as presentation:
    # Documenteigenschappen ophalen
    documentProperties = presentation.document_properties

    # Aangepaste eigenschappen toevoegen
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Eigenaam ophalen op een bepaalde index
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Geselecteerde eigenschap verwijderen
    documentProperties.remove_custom_property(getPropertyName)

    # Presentatie opslaan
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot en wijzigen van aangepaste eigenschappen**
Aspose.Slides for Python via .NET stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.
```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die de PPTX vertegenwoordigt
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Maak een referentie naar het document_properties-object dat aan de Presentation is gekoppeld
    documentProperties = presentation.document_properties

    # Toegang tot en wijzig aangepaste eigenschappen
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Toon namen en waarden van aangepaste eigenschappen
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Wijzig waarden van aangepaste eigenschappen
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Sla uw presentatie op naar een bestand
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` retourneert de waarde via de één‑elementlijst die als tweede argument wordt doorgegeven, en de opgeslagen waarde wordt omgezet naar het type van het element dat al in die lijst aanwezig is. Het voorbeeld hierboven gebruikt `[""]`, zodat string‑eigenschappen worden gelezen; om een eigenschap die als een getal is opgeslagen te lezen, geef een numerieke placeholder zoals `[0]`—anders wordt een `InvalidCastException` opgegooid.

## **Taal voor proeflezen instellen**
Aspose.Slides biedt de eigenschap `Language_Id` (beschikbaar via de [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/)‑klasse) om de taal voor proeflezen in een PowerPoint‑document in te stellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze Python‑code laat zien hoe u de proefleestaal voor een PowerPoint‑bestand instelt:
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

    # stel de Id van een proefleestaal in
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Standaardtaal instellen**
Deze Python‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:
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

## **Live‑voorbeeld**
Probeer de online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![Bekijk & bewerk PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal deel van de presentatie uit en kunnen niet volledig verwijderd worden. U kunt echter hun waarden wijzigen of, indien de betreffende eigenschap dit toestaat, deze leegmaken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet eerst te verwijderen of te controleren, aangezien Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de presentatie volledig te laden?**

Ja. Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) en vervolgens [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/python-net/examine-presentation/) voor een volledig voorbeeld van rapportage en format‑specifieke beperkingen.