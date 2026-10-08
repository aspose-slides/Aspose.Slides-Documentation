---
title: Configureer lettertype‑vervanging in presentaties met Python via Java
linktitle: Lettertype‑vervanging
type: docs
weight: 70
url: /nl/python-java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertype‑vervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en controleer de vervangen lettertypen in Aspose.Slides voor Python via Java bij het renderen of converteren van PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertype‑vervanging stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde uitvoer; het verandert niet het lettertype dat aan de inhoud van de presentatie is toegewezen.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides zal toepassen tijdens het renderen. Dit helpt de uitvoer consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

Als een lettertype beschikbaar is maar geen eigen vet type heeft, zie dan [Lettertypen zonder een eigen vet type](/slides/nl/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe de getroffen tekst tijdens PDF‑export gerasterd kan worden en welke gevolgen dit heeft voor tekstselectie, zoeken en schalen.

## **Lettertype‑vervangingen ophalen**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/)‑objecten die de oorspronkelijke en vervangen lettertype‑namen identificeren.

Het volgende Python‑voorbeeld geeft alle lettertype‑vervangingen van een presentatie weer:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Lettertype‑vervangingen ophalen voor geselecteerde dia’s**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions)‑overload met een Java‑integer‑array‑argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia’s te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia’s zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een server of container voorbereidt, of renderingsverschillen diagnosticeert zonder ongerelateerde dia’s te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. Daarentegen gebruikt de [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)‑collectietoegang nul‑gebaseerde indexering, zodat dezelfde dia wordt benaderd als `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het opbouwen van de array om off‑by‑one‑fouten te vermijden.

Roep de overload aan via de [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager)‑methode. Deze retourneert alleen de vervangingen die tijdens het renderen van de geselecteerde dia’s zijn bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/)‑object dat de oorspronkelijke en vervangen lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/python-java/custom-font/).

Dezelfde vervanging kan vereist zijn door meer dan één geselecteerde dia. Dedupliceer de resultaten wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld rapporteert elke teruggegeven vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertypekoppelingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

De [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/)‑klasse biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Gebruik wanneer |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) zonder argumenten | U hebt vervangingen nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) met een Java‑integer‑array | U hebt vervangingen nodig voor een geselecteerd bereik, incrementele controle of gedeeltelijke export. |

## **Lettertype‑vervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangingslettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe via de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList)‑methode.
6. Render of converteer de presentatie.

Het volgende Python‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}
Voor een onvoorwaardelijke wijziging van de in een presentatie gebruikte lettertypen, zie [Lettertype‑vervanging](/slides/nl/python-java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijkings‑lettertypen**

Lettertype‑vervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor reguliere tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is opgegeven.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** hiervoor niet vervangen, en het renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/python-java/custom-font/).

Deze beperking geldt voor de lay‑out van vergelijkingen. De hierboven beschreven vervangingsregels blijven wel van toepassing op reguliere presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑vervanging?**

[Font replacement](/slides/nl/python-java/font-replacement/) wijzigt opzettelijk één lettertype naar een ander door de hele presentatie heen. Lettertype‑vervanging kiest een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden vervangingsregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/python-java/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen vervangingsregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om vervanging te voorkomen?**

Ja. U kunt [extern lettertypen laden](/slides/nl/python-java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen vervangingsresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, zodat een lettertype dat op het ene apparaat beschikbaar is, op een ander apparaat mogelijk moet worden vervangen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/python-java/custom-font/), en [embed fonts](/slides/nl/python-java/embedded-font/) wanneer licenties dat toestaan. U kunt ook [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) aanroepen vóór export om onverwachte vervangingen te identificeren.