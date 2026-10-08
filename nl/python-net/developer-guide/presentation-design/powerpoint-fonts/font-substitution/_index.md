---
title: Lettertypevervanging configureren in presentaties met Python
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/python-net/font-substitution/
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
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en inspecteer de vervangende lettertypen in Aspose.Slides voor Python via .NET bij het renderen of converteren van PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat om een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde output; het verandert het toegewezen lettertype van de presentatie‑inhoud niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

Als een lettertype beschikbaar is maar geen specifieke vette stijl heeft, zie [Lettertypen behandelen zonder een specifieke vette stijl](/slides/nl/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe de betreffende tekst te rasteren tijdens PDF‑export en de gevolgen voor tekstselectie, zoeken en schalen.

## **Lettertypevervangingen ophalen**

Gebruik de [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) objecten die de originele en vervangen lettertype‑namen identificeren.

Het volgende Python‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Lettertypevervangingen ophalen voor geselecteerde dia's**

Gebruik [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) met een lijst van dia‑indexen om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertypepakket voorbereidt voor een server of container, of rendering‑verschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De lijst bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. In tegenstelling tot de [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collectie, die nulgebaseerd is, wordt diezelfde dia benaderd als `presentation.slides[0]`. Houd dit verschil in gedachten bij het samenstellen van de lijst om één‑off‑by‑one‑fouten te voorkomen.

Roep de methode aan via de eigenschap [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Deze retourneert alleen de vervangingen die zijn bepaald tijdens het renderen van de geselecteerde dia's. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) object dat de originele en vervangen lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/python-net/custom-font/).

Dezelfde vervanging kan door meer dan één geselecteerde dia vereist zijn. Dedupliceer de resultaten wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld geeft elke teruggegeven vervanging weer en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

De [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) klasse biedt beide vormen van de methode. Kies er één op basis van de reikwijdte van de render‑operatie:

| Methode‑aanroep | Gebruik wanneer |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) zonder argumenten | U heeft vervangingen nodig voor de volledige presentatie. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) met een lijst van dia‑indexen | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle of een gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangingslettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) met de [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) voorwaarde.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe aan de eigenschap [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Render of converteer de presentatie.

Het volgende Python‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Voor een onvoorwaardelijke wijziging van de lettertypen die in de hele presentatie worden gebruikt, zie [Lettertypevervanging](/slides/nl/python-net/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijkinglettertypen**

Lettertypevervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat wordt gebruikt tijdens rendering en conversie. Ze werken voor reguliere tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is gespecificeerd.

Office Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay-out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** voor dit doel niet vervangen, en rendering kan nog steeds melden dat **Cambria Math** nodig is.

Om zo’n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/python-net/custom-font/).

Deze beperking geldt voor de lay-out van vergelijkingen. De hierboven beschreven vervangingsregels blijven van toepassing op reguliere presentatie‑tekst.

## **Veelgestelde vragen**

**Wat is het verschil tussen lettertypevervanging en lettertypesubstitutie?**

[Lettertypevervanging](/slides/nl/python-net/font-replacement/) wijzigt opzettelijk één lettertype naar een ander in de hele presentatie. Lettertypesubstitutie kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels maken deel uit van de [lettertype‑selectiesequentie](/slides/nl/python-net/font-selection-sequence/) tijdens rendering en conversie. Met `WHEN_INACCESSIBLE` wordt een regel alleen gebruikt wanneer Aspose.Slides niet bij het bronlettertype kan komen.

**Wat gebeurt er wanneer een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [externe lettertypen laden](/slides/nl/python-net/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens rendering en conversie.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, dus een lettertype dat op één machine beschikbaar is, kan op een andere substitutie vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertypebestanden en -versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/python-net/custom-font/), en [lettertypen insluiten](/slides/nl/python-net/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) aanroepen vóór export om onverwachte substituties te identificeren.