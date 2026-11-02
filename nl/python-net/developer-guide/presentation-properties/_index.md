---
title: Beheer presentatie-eigenschappen met Python
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/python-net/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- ingebouwde-eigenschappen
- aangepaste-eigenschappen
- geavanceerde-eigenschappen
- beheer-eigenschappen
- wijzig-eigenschappen
- document-metadata
- metadata bewerken
- proef-taal
- standaard-taal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides for Python via .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint-bestanden."
---
## **Inleiding**

Aspose.Slides for Python via .NET ondersteunt **ingebouwde** en **aangepaste** document‑eigenschappen. Gebruik deze eigenschappen om metadata van een presentatie te lezen en bij te werken, zoals auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides stelt u in staat om document‑eigenschappen van een presentatie te beheren via de [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)‑klasse. Een exemplaar van deze klasse wordt geretourneerd door [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). De onderstaande voorbeelden tonen hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de applicatie‑ en producent‑metadata bij het opslaan van presentaties; deze velden geven aan welke software de uitvoer heeft gecreëerd.
{{% /alert %}}

## **Beheer presentatie‑eigenschappen**

Document‑eigenschappen slaan beschrijvende informatie op naast de inhoud van de presentatie. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals titel, auteur en statistieken van het document.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam‑/waarde‑paren op.

Aspose.Slides for Python via .NET biedt toegang tot beide categorieën. In PowerPoint selecteert u **Bestand → Info → Eigenschappen → Geavanceerde eigenschappen** om de document‑metadata te bekijken. Het dialoogvenster groept informatie in tabbladen zoals **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Gebruik het tabblad **Aangepast** om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openings‑wachtwoord beschermt normaal zowel de inhoud van de presentatie als de document‑eigenschappen. Wanneer een presentatie versleuteld is met [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ingesteld op `False`, blijven de document‑eigenschappen openbaar. Een applicatie kan dan [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) instellen op `True` en de openbare metadata lezen zonder het openings‑wachtwoord op te geven.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) bepaalt wat Aspose.Slides laadt; het decodeert niets. Als de eigenschappen in de versleuteling zijn meegepakt, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de document‑eigenschappen openbaar zijn gelaten. Het controleert de laadmethode via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) en leest vervolgens de ingebouwde eigenschappen via [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

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

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, lay-outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties dienen altijd [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) te controleren voordat ze een bewerking uitvoeren die het volledige objectmodel van de presentatie vereist.

{{% alert color="warning" title="Security" %}}
Openbare metadata kan auteursnamen, titels, onderwerps, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexerings‑, classificatie‑, zoek‑ of document‑beheersystemen een specifieke noodzaak hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen met [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) bedoeld om alleen openbare metadata te lezen. Aspose.Slides kan geen gewijzigde eigenschappen opslaan vanuit dat uitsluitend‑metadata‑object, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openings‑wachtwoord en een volledige lading.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare document‑eigenschappen en een bekend openings‑wachtwoord. Het opent de volledige presentatie met [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), werkt de openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt met [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) gecontroleerd of de versleuteling behouden blijft en wordt de openbare metadata zonder wachtwoord opnieuw geopend om de nieuwe waarden te verifiëren:

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

Als een applicatie niet is toegestaan om de presentatie‑inhoud te decoderen of te laden, moet zij de openbare eigenschappen van een versleuteld PPTX‑bestand beschouwen als alleen‑lezen.

## **Toegang tot ingebouwde eigenschappen**

De [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)‑klasse biedt ingebouwde metadata via getypeerde eigenschappen, waaronder [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) en [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af naar de console. De waarden hangen af van de invoer‑presentatie; sommige velden kunnen leeg zijn.

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

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, kent u waarden toe aan de schrijfbare eigenschappen die beschikbaar zijn via [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Dit voorbeeld opent een bestaande presentatie, stelt [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) en [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) in, en slaat de bijgewerkte presentatie vervolgens op met [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). De opgeslagen PPTX bevat de nieuwe metadata.

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

## **Beheer de hyperlinkbasis**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) slaat de document‑brede basis op voor relatieve hyperlinks. Dit is nuttig bij het verplaatsen van een presentatie en bijbehorende gekoppelde bestanden naar een andere locatie. Het staat los van de individuele hyperlink‑eigenschap [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): het wijzigen van de basis herschrijft de opgeslagen linkadressen niet en verandert geen absolute bestemmingen.

Het voorbeeld vereist een presentatie met zowel een relatieve link, bijvoorbeeld `target.html`, als een absolute link naar een bestand of website. Het leest de bestaande basis, kent een nieuwe basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Daarna wordt de basis gewist met `""` en wordt de lege waarde geverifieerd in een apart opgeslagen bestand. Vervang het voorbeeld‑basisadres door de locatie van uw gekoppelde bestanden.

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

De twee verificatie‑berichten moeten `True` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen ongewijzigd.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis naar de map `old` verwees. Na het wijzigen van de basis naar de map `new`, het opslaan en opnieuw openen van de presentatie, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op waarvoor geen ingebouwd veld bestaat. De methode [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) laat u een waarde toewijzen via de naam van de eigenschap. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een geheel‑getal‑versie‑waarde toe, en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Het toekennen van een waarde aan een reeds bestaande naam vervangt de waarde van die eigenschap.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste eigenschappen openen en wijzigen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) om erover te itereren. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) accepteert een index beginnend bij nul en retourneert de naam die wordt gebruikt door [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Het voorbeeld vereist een presentatie waarvan alle aangepaste eigenschappen strings zijn. Het drukt elke originele naam en waarde af, vervangt elke waarde door een genummerde string, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen veranderingen aan.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) retourneert de waarde via de één‑element‑lijst die als tweede argument wordt doorgegeven. De placeholder moet overeenkomen met het type van de opgeslagen eigenschap: gebruik `[""]` voor een string of `[0]` voor een geheel getal. Een type‑mismatch veroorzaakt een `InvalidCastException`; kies de placeholder volgens uw aangepaste‑eigenschap‑schema.

## **Live‑voorbeeld**

Probeer de [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata)‑online‑app om te zien hoe u met document‑eigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren, aangezien Aspose.Slides automatisch de waarde van de eigenschap bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) en vervolgens [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) om opgeslagen document‑metadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑instantie te creëren. Zie [Build a Lightweight Presentation Inventory](/slides/nl/python-net/examine-presentation/) voor een volledig rapport‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. De presentatie moet versleuteld zijn met [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ingesteld op `False`, en deze moet worden geladen met [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ingesteld op `True`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑document‑eigenschappen‑modus?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het correcte openings‑wachtwoord.