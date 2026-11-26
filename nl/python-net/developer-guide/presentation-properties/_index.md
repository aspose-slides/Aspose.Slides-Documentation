---
title: Beheer presentatie-eigenschappen met Python
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/python-net/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controleertaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides for Python via .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint-bestanden."
---
## **Inleiding**

Aspose.Slides for Python via .NET ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides stelt je in staat om met presentatiedocumenteigenschappen te werken via de klasse [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Een instantie van deze klasse wordt geretourneerd door [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). De volgende voorbeelden laten zien hoe je deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de applicatie- en producent-metadata bij het opslaan van presentaties; deze velden geven aan welke software de uitvoer heeft gecreëerd.
{{% /alert %}}

## **Beheer presentatieeigenschappen**

Documenteigenschappen bewaren beschrijvende informatie naast de presentatie-inhoud. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde-paren op.

Aspose.Slides for Python via .NET biedt toegang tot beide categorieën. In PowerPoint selecteer **File → Info → Properties → Advanced Properties** om de documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Summary**, **Statistics**, **Contents** en **Custom**. Gebruik het **Custom**-tabblad om door-de-gebruiker-gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen uit een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de presentatie-inhoud als de documenteigenschappen. Wanneer een presentatie is versleuteld met [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ingesteld op `False`, blijven de documenteigenschappen openbaar. Een applicatie kan dan [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) op `True` zetten en de openbare metadata lezen zonder het openingswachtwoord op te geven.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen bij de versleuteling zijn opgenomen, faalt het laden ervan zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het controleert de laadmodus via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) en leest vervolgens ingebouwde eigenschappen via [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

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

In deze modus wordt de dia-inhoud niet geladen. Dia's, masters, layouts, shapes, media en andere presentatie-objecten zijn niet beschikbaar. Applicaties moeten altijd [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) controleren voordat ze een bewerking uitvoeren die het volledige presentatie-objectmodel vereist.

{{% alert color="warning" title="Security" %}}
Openbare metadata kan namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexering, classificatie, zoeken of document-beheersystemen een specifieke eis hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen van een versleutelde presentatie bijwerken**

Voor een versleuteld PPTX-bestand is een presentatie die is geladen met [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) bedoeld om openbare metadata te lezen. Aspose.Slides kan geen gewijzigde eigenschappen opslaan vanuit dat alleen-metadata-object, want de openbare eigenschappen moeten consistent blijven met de overeenkomstige gegevens binnen de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openingswachtwoord en een volledige lading.

Het voorbeeld vereist een versleutelde PPTX-presentatie met openbare documenteigenschappen en een bekend openingswachtwoord. Het opent de volledige presentatie met [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens gebruikt het [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) om te verifiëren dat de versleuteling behouden blijft en opent de openbare metadata opnieuw zonder wachtwoord om de nieuwe waarden te controleren:

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

Als een applicatie niet mag ontcijferen of de presentatie-inhoud laden, moet hij openbare eigenschappen van een versleuteld PPTX-bestand behandelen als alleen-lezen.

## **Toegang tot ingebouwde eigenschappen**

De klasse [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) maakt ingebouwde metadata beschikbaar via getypeerde eigenschappen, waaronder [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) en [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Dit voorbeeld opent een bestaande presentatie en print de opgeslagen metadata naar de console. De waarden hangen af van de invoerpresentatie; sommige velden kunnen leeg zijn.

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

### **Rapport revisienummer en bewerkingstijd**

Om het revisienummer en de totale bewerkingstijd voor elk PPTX-bestand in de map `presentations` te rapporteren, gebruik [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) om de [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) op te halen zonder de dia's te laden voor bewerking. Python toont de duur als een `timedelta`, inclusief het aantal dagen wanneer de opgenomen tijd 24 uur bereikt.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

Voor een presentatie met 1 dag, 2 uur en 5 minuten opgenomen bewerkingstijd, bevat het rapport de volgende rij.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) is schrijfbare metadata. Alleen de waarde kan niet bepalen hoe vaak de presentatie is opgeslagen of de versiegeschiedenis reconstrueren.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) rapporteert de bewerkingstijd die in het bestand is opgeslagen. Een waarde van `0:00:00` betekent dat de opgenomen duur nul is, zelfs als iemand de presentatie heeft bewerkt.

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, wijs waarden toe aan de schrijfbare eigenschappen die worden blootgesteld door [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Dit voorbeeld opent een bestaande presentatie, stelt [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) en [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) in, en slaat de bijgewerkte presentatie op met [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). De opgeslagen PPTX bevat de nieuwe metadata.

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

## **Beheer van de hyperlink-basis**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) slaat de document-niveau basis op voor relatieve hyperlinks. Dit is nuttig wanneer een presentatie en de gekoppelde bestanden naar een andere locatie worden verplaatst. Het staat los van de individuele hyperlink-eigenschap [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): het wijzigen van de basis herschrijft niet de opgeslagen koppelingen of verandert absolute bestemmingen.

Het voorbeeld vereist een presentatie die zowel een relatieve koppeling, zoals `target.html`, als een absolute koppeling naar een bestand of website bevat. Het leest de bestaande basis, kent een nieuw basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Daarna wist het de basis met `""` en verifieert de lege waarde in een afzonderlijk opgeslagen bestand. Vervang het voorbeeldbasisadres door de locatie van jouw gekoppelde bestanden.

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

De twee verificatie-berichten zouden `True` moeten afdrukken. Het wissen van de basis laat de individuele hyperlink-adressen onaangetast.

Een relatieve koppeling naar `target.pptx` opende `old/target.pptx` toen de basis verwijst naar de map `old`. Na het veranderen van de basis naar de map `new`, opslaan en opnieuw openen, opende dezelfde koppeling `new/target.pptx`. Een absolute koppeling bleef hetzelfde bestand openen. Test je relatieve koppelingen in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatie-eigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op die geen overeenkomstig ingebouwd veld hebben. De methode [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) laat je een waarde toewijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een geheel getal-versie-waarde toe, en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Een waarde toewijzen aan een bestaande naam vervangt de waarde van die eigenschap.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot en aanpassen van aangepaste eigenschappen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) om erover te itereren. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) accepteert een nul-gebaseerde index en retourneert de naam die wordt gebruikt door [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Het voorbeeld vereist een presentatie waarvan alle aangepaste eigenschappen strings zijn. Het drukt elke originele naam en waarde af, vervangt elke waarde door een genummerde string, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen wijzigingen aan.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) retourneert de waarde via de één-element-lijst die als tweede argument wordt doorgegeven. De placeholder moet overeenkomen met het type van de opgeslagen eigenschap: gebruik `[""]` voor een string of `[0]` voor een geheel getal. Een type-mismatch veroorzaakt een `InvalidCastException`; kies de placeholder volgens je aangepaste-eigenschap-schema.

## **Live-voorbeeld**

Probeer de online app [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) om te zien hoe je met documenteigenschappen werkt via de Aspose.Slides-API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken integraal deel uit van de presentatie en kunnen niet volledig worden verwijderd. Je kunt ze echter wel wijzigen of, indien de specifieke eigenschap dat toelaat, leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als je een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. Je hoeft de eigenschap niet eerst te verwijderen of te controleren, want Aspose.Slides werkt de eigenschapswaarde automatisch bij.

**Kan ik presentatie-eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) en daarna [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/python-net/examine-presentation/) voor een volledig rapportage-voorbeeld en format-specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet versleuteld zijn met [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ingesteld op `False`, en moet worden geladen met [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ingesteld op `True`.

**Kan ik een versleuteld PPTX-bestand bijwerken in alleen-document-eigenschappen-modus?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX-bestand vereist het volledig laden van de presentatie met het juiste openingswachtwoord.