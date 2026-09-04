---
title: Beheer presentatie‑eigenschappen met Python
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/python-net/presentation-properties/
keywords:
- PowerPoint-eigenschappen
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
description: "Beheer presentatie‑eigenschappen in Aspose.Slides voor Python via .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint‑bestanden."
---
## **Introductie**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/) klasse. Een instantie van deze klasse wordt teruggegeven door de [Presentation.document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/document_properties/) eigenschap. De volgende voorbeelden laten zien hoe deze eigenschappen gelezen, gewijzigd en beheerd kunnen worden.

{{% alert color="info" title="Note" %}}
Let op dat u geen waarden kunt instellen voor de **Application**- en **Producer**-velden, omdat Aspose Ltd. en Aspose.Slides for Python via .NET x.x.x in deze velden worden weergegeven.
{{% /alert %}} 

## **Beheer Presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen toe te voegen aan presentatiebestanden. Deze documenteigenschappen maken het mogelijk om nuttige informatie op te slaan samen met de documenten (presentatiebestanden). Er zijn twee soorten documenteigenschappen, namelijk:

- Systeembedefinieerde (Built-in) eigenschappen
- Gebruikersgedefinieerde (Custom) eigenschappen

**Built-in** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, documentstatistieken enzovoort. **Custom** eigenschappen zijn diegenen die door gebruikers worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides for Python via .NET kunnen ontwikkelaars de waarden van zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatiebestanden te beheren. Het enige wat u hoeft te doen is op het Office‑pictogram klikken en vervolgens het menu‑item **Prepare | Properties | Advanced Properties** van Microsoft PowerPoint 2007 selecteren. Nadat u het menu‑item **Advanced Properties** hebt gekozen, verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren. In het **Properties Dialog** kunt u zien dat er veel tabbladen zijn, zoals **General, Summary, Statistics, Contents and Custom**. Al deze tabbladen maken het mogelijk verschillende soorten informatie met betrekking tot de PowerPoint‑bestanden te configureren. Het tabblad **Custom** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de presentatiewaarde als de documenteigenschappen. Wanneer een presentatie is versleuteld met [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ingesteld op `False`, blijven de documenteigenschappen openbaar. Een applicatie kan dan [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/only_load_document_properties/) instellen op `True` en de openbare metadata lezen zonder het openingswachtwoord op te geven.

`only_load_document_properties` bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen deel uitmaakten van de versleuteling, mislukt het laden ervan zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld controleert de laadmodus via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) en leest vervolgens de ingebouwde eigenschappen via [Presentation.document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/document_properties/):

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

In deze modus wordt de inhoud van dia's niet geladen. Dia's, masters, indelingen, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd `is_only_document_properties_loaded` controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Security" %}}
Openbare metadata kan auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexering, classificatie, zoeken of document‑beheersystemen een specifieke vereiste hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen met `only_load_document_properties` bedoeld om openbare metadata te lezen. Aspose.Slides kan de gewijzigde eigenschappen van dat metadata‑enige object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de overeenkomstige gegevens binnen de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openingswachtwoord en een volledige load.

Het volgende voorbeeld opent de presentatie met [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/is_encrypted/) gebruikt om te verifiëren dat de versleuteling behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te controleren:

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

Als een applicatie geen toestemming heeft om de presentatie‑inhoud te ontsleutelen of te laden, moet deze de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen, zoals blootgelegd door het **IDocumentProperties**‑object, omvatten: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creatiedatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse die de presentatie vertegenwoordigt
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Maak een referentie naar het object dat aan Presentation is gekoppeld
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

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is net zo eenvoudig als ze te benaderen. U kunt eenvoudig een tekenreeks toewijzen aan elke gewenste eigenschap en de waarde van de eigenschap wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van het presentatie‑bestand kunnen wijzigen.

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse die de presentatie vertegenwoordigt
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Maak een referentie naar het object dat aan Presentation is gekoppeld
    documentProperties = presentation.document_properties

    # Stel de ingebouwde eigenschappen in
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # sla de presentatie op in een bestand
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste presentaties‑eigenschappen toevoegen**

Aspose.Slides for Python via .NET stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe u de aangepaste eigenschappen voor een presentatie kunt instellen.

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse
with slides.Presentation() as presentation:
    # Documenteigenschappen ophalen
    documentProperties = presentation.document_properties

    # Aangepaste eigenschappen toevoegen
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Eigenschapsnaam ophalen op een bepaalde index
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Geselecteerde eigenschap verwijderen
    documentProperties.remove_custom_property(getPropertyName)

    # Presentatie opslaan
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides for Python via .NET stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse die de PPTX vertegenwoordigt
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Maak een referentie naar het document_properties‑object dat bij de Presentation hoort
    documentProperties = presentation.document_properties

    # Toegang tot en wijziging van aangepaste eigenschappen
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Toon namen en waarden van aangepaste eigenschappen
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Wijzig waarden van aangepaste eigenschappen
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # sla de presentatie op in een bestand
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` geeft de waarde terug via de één‑element lijst die als tweede argument wordt doorgegeven, en de opgeslagen waarde wordt geconverteerd naar het type van het element dat al in die lijst staat. Het bovenstaande voorbeeld gebruikt `[""]`, waardoor tekenreeks‑eigenschappen worden gelezen; om een eigenschap die als getal is opgeslagen te lezen, geeft u een numerieke placeholder mee, zoals `[0]` — anders wordt er een `InvalidCastException` opgegooid.

## **Proofing‑taal instellen**

Aspose.Slides biedt de `Language_Id`‑eigenschap (blootgelegd door de [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/) klasse) waarmee u de proefleestaal voor een PowerPoint‑document kunt instellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze Python‑code laat zien hoe u de proefleestaal voor een PowerPoint kunt instellen:

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

Deze Python‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

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

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![Bekijk & Bewerk PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

**Built-in** eigenschappen vormen een integraal onderdeel van de presentatie en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren, aangezien Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationfactory/get_presentation_info/) en vervolgens [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/read_document_properties/) om de opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/python-net/examine-presentation/) voor een compleet rapportage‑voorbeeld en formaat‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet versleuteld zijn met `encrypt_document_properties` ingesteld op `False`, en moet geladen worden met `only_load_document_properties` ingesteld op `True`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus alleen‑document‑eigenschappen?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledig laden van de presentatie met het juiste openingswachtwoord.