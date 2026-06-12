---
title: Beheer presentatie‑eigenschappen met Python
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/python-net/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- document‑eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document‑metadata
- metadata bewerken
- controlertaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides for Python via .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee typen documenten‑eigenschappen: **Ingebouwde** en **Aangepaste**. Beide eigendomstypen zijn eenvoudig toegankelijk en te beheren met de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om met presentatiedocument‑eigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/)‑klasse. Een instantie van deze klasse wordt geretourneerd door de eigenschap [Presentation.document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/document_properties/). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="primary" %}} 
Let op dat u geen waarden kunt instellen voor de velden **Application** en **Producer**, omdat Aspose Ltd. en Aspose.Slides for Python via .NET x.x.x in deze velden worden weergegeven.
{{% /alert %}} 

## **Beheer presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan presentatie‑bestanden toe te voegen. Deze documenten‑eigenschappen maken het mogelijk om nuttige informatie samen met de documenten (presentatie‑bestanden) op te slaan. Er zijn twee soorten documenten‑eigenschappen:

- Systeem‑gedefinieerde (Ingebouwde) eigenschappen
- Gebruiker‑gedefinieerde (Aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de titel, de naam van de auteur, documentstatistieken, enzovoort. **Aangepaste** eigenschappen zijn die welke door de gebruiker worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides for Python via .NET kunnen ontwikkelaars de waarden van ingebouwde en aangepaste eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het mogelijk om de documenten‑eigenschappen van presentaties te beheren. Het enige wat u hoeft te doen is op het Office‑pictogram te klikken en vervolgens **Prepare | Properties | Advanced Properties** te kiezen in Microsoft PowerPoint 2007. Nadat u **Advanced Properties** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenten‑eigenschappen van het PowerPoint‑bestand kunt beheren. In het **Properties Dialog** ziet u verschillende tabbladen zoals **General, Summary, Statistics, Contents and Custom**. Al deze tabbladen stellen u in staat verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Custom** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen, die worden blootgelegd door het **IDocumentProperties**‑object, omvatten: **Creator(Author)**, **Description**, **Keywords**, **Created** (aanmaakdatum), **Modified** (wijzigingsdatum), **Printed** (datum laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**
```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die de presentatie vertegenwoordigt
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Maak een referentie naar het object dat gekoppeld is aan Presentation
    documentProperties = pres.document_properties

    # Geef de ingebouwde eigenschappen weer
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

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentatie‑bestanden is net zo eenvoudig als het openen ervan. U kunt eenvoudig een tekenreeks aan een gewenste eigenschap toewijzen en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde document‑eigenschappen van een presentatie‑bestand kunnen wijzigen.
```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die de Presentation vertegenwoordigt
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Maak een referentie naar het object dat gekoppeld is aan Presentation
    documentProperties = presentation.document_properties

    # Stel de ingebouwde eigenschappen in
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # sla uw presentatie op naar een bestand
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aspose.Slides for Python via .NET stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen voor presentatie‑document‑eigenschappen. Hieronder staat een voorbeeld dat laat zien hoe u aangepaste eigenschappen voor een presentatie kunt instellen.
```py
import aspose.slides as slides

# Instantieer de Presentation-klasse
with slides.Presentation() as presentation:
    # Documenteigenschappen ophalen
    documentProperties = presentation.document_properties

    # Aangepaste eigenschappen toevoegen
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # De eigenschapsnaam op een bepaalde index ophalen
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Geselecteerde eigenschap verwijderen
    documentProperties.remove_custom_property(getPropertyName)

    # Presentatie opslaan
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste eigenschappen openen en wijzigen**

Aspose.Slides for Python via .NET stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt openen en wijzigen.
```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Maak een referentie naar het document_properties-object dat gekoppeld is aan de Presentatie
    documentProperties = presentation.document_properties

    # Toegang tot en wijzig aangepaste eigenschappen
    for i in range(documentProperties.count_of_custom_properties):
        # Toon namen en waarden van aangepaste eigenschappen
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Wijzig waarden van aangepaste eigenschappen
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # sla uw presentatie op naar een bestand
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlertaal instellen**

Aspose.Slides biedt de eigenschap `Language_Id` (beschikbaar via de [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/)‑klasse) waarmee u de controlertaal voor een PowerPoint‑document kunt instellen. De controlertaal is de taal waarvoor spelling en grammatica in de PowerPoint‑presentatie worden gecontroleerd.

Deze Python‑code laat zien hoe u de controlertaal voor een PowerPoint‑bestand instelt:
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

    # stel de Id van een controlertaal in
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

## **Live voorbeeld**

Probeer de online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met document‑eigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien de specifieke eigenschap het toestaat, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig om de eigenschap vooraf te verwijderen of te controleren, aangezien Aspose.Slides de eigenschapswaarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja, u kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door de [get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/)‑methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/)‑klasse te gebruiken. Vervolgens kunt u de [read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/)‑methode van de [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/)‑klasse gebruiken om de eigenschappen efficiënt te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.