---
title: Lettertypevervanging configureren in presentaties met Python via Java
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/python-java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en bekijk de vervangen lettertypen in Aspose.Slides voor Python via Java bij het renderen of converteren van PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Lettertypevervanging maakt het mogelijk dat Aspose.Slides een beschikbaar lettertype gebruikt in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde output; het verandert het aan de presentatie‑inhoud toegewezen lettertype niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertypevervangingen ophalen**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions) methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstitutioninfo/) objecten die de oorspronkelijke en vervangende lettertype‑namen identificeren.

Het volgende Python‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

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

## **Lettertypevervangingen ophalen voor geselecteerde dia's**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions) overload met een Java‑integer‑array‑argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhangen van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een server of container voorbereidt, of renderingsverschillen diagnosticeert zonder niet‑relevante dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` duidt de eerste dia aan. Daarentegen gebruikt de [Presentation.getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides) collectie‑accessor nul‑gebaseerde indexering, zodat dezelfde dia wordt benaderd als `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het bouwen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getFontsManager) methode. Deze retourneert alleen de vervangingen die tijdens het renderen van de geselecteerde dia's zijn bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstitutioninfo/) object dat de oorspronkelijke en vervangende lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstrulecollection/), en [extern ingeladen lettertypen](/slides/nl/python-java/custom-font/).

Dezelfde vervanging kan door meer dan één geselecteerde dia vereist zijn. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld rapporteert elke geretourneerde vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

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

De [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) klasse biedt beide overloads. Kies er één op basis van de scope van de render‑operatie:

| Overload | Wanneer te gebruiken |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions) zonder argumenten | U heeft vervangingen nodig voor de gehele presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions) met een Java‑integer‑array | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bron‑lettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstrule/) aan met de [WhenInaccessible](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) voorwaarde.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe met behulp van de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) methode.
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

{{% alert color="info" title="Note" %}}
Voor een onvoorwaardelijke wijziging van de lettertypen die in de hele presentatie worden gebruikt, zie [Font Replacement](/slides/nl/python-java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskunde‑formule‑lettertypen**

Lettertypevervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat wordt gebruikt tijdens rendering en conversie. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is gespecificeerd.

Office‑Math‑formules hebben een extra vereiste. Als een formule **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de formule te berekenen en te renderen. Een regel die een ander wiskunde‑lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** hiervoor niet vervangen, en de rendering kan nog steeds melden dat **Cambria Math** vereist is.

Om zo'n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [external font](/slides/nl/python-java/custom-font/).

Deze beperking geldt voor de formule‑lay‑out. De hierboven beschreven vervangingsregels blijven wel van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen font replacement en font substitution?**

[Font replacement](/slides/nl/python-java/font-replacement/) wijzigt opzettelijk een lettertype naar een ander door de hele presentatie heen. Font substitution kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden vervangingsregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/python-java/font-selection-sequence/) tijdens rendering en conversie. Bij `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides het bron‑lettertype niet kan benaderen.

**Wat gebeurt er als een lettertype ontbreekt en er geen vervangingsregel is geconfigureerd?**

Aspose.Slides kiest het meest passende beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om vervanging te vermijden?**

Ja. U kunt [load external fonts](/slides/nl/python-java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens rendering en conversie.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent zelf verantwoordelijk voor het leveren van de lettertypen en het naleven van hun licenties.

**Kunnen vervangingsresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, waardoor een lettertype dat op de ene machine beschikbaar is, op een andere machine vervanging kan vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en versies op elke machine of container, [load required external fonts](/slides/nl/python-java/custom-font/), en [embed fonts](/slides/nl/python-java/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions) aanroepen vóór export om onverwachte vervangingen te identificeren.