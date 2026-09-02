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
description: "Configureer regels voor lettertypevervanging en inspecteer de vervangen lettertypen in Aspose.Slides voor Python via .NET bij het renderen of converteren van PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat om een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde output; het wijzigt niet het lettertype dat aan de inhoud van de presentatie is toegewezen.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides tijdens het renderen zal toepassen. Dit helpt de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertypevervangingen ophalen**

Gebruik de [FontsManager.get_substitutions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/) methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsubstitutioninfo/) objecten die de originele en vervangen lettertype‑namen identificeren.

Het volgende Python‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Lettertypevervangingen ophalen voor geselecteerde dia's**

Gebruik [FontsManager.get_substitutions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/) met een lijst van dia‑indexen om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimale lettertype‑package voor een server of container voorbereidt, of renderingsverschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De lijst bevat één‑gebaseerde dia‑indexen: `1` duidt de eerste dia aan. Daarentegen is de [Presentation.slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/) collectie nul‑gebaseerd, zodat dezelfde dia wordt benaderd als `presentation.slides[0]`. Houd dit verschil in gedachten bij het bouwen van de lijst om één‑off‑by‑one fouten te voorkomen.

Roep de methode aan via de eigenschap [Presentation.fonts_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/fonts_manager/). Deze retourneert alleen de vervangingen die tijdens het renderen van de geselecteerde dia's zijn bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsubstitutioninfo/) object dat de originele en vervangen lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/python-net/custom-font/).

Dezelfde vervanging kan door meer dan één geselecteerde dia vereist zijn. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld meldt elke geretourneerde vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

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

De klasse [FontsManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/) biedt beide vormen van de methode. Kies er één op basis van de reikwijdte van de render‑operatie:

| Methode‑aanroep | Gebruik wanneer |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/) zonder argumenten | U heeft vervangingen nodig voor de volledige presentatie. |
| [get_substitutions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/) met een lijst van dia‑indexen | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Vervangingsregels voor lettertypen instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangings‑lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsubstrule/) met de voorwaarde [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsubstcondition/).
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe aan de eigenschap [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
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
Voor een onvoorwaardelijke wijziging van de lettertypen die in de hele presentatie worden gebruikt, zie [Font Replacement](/slides/nl/python-net/font-replacement/).
{{% /alert %}}

## **Beperkingen voor lettertypen in wiskundige vergelijkingen**

Vervangingsregels voor lettertypen maken deel uit van het standaard lettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is gespecificeerd.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides die exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** hiervoor niet vervangen, en de rendering kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/python-net/custom-font/).

Deze beperking geldt voor de vergelijking‑lay‑out. De hierboven beschreven vervangingsregels blijven wel van toepassing op gewone presentatietekst.

## **Veelgestelde vragen**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Font replacement](/slides/nl/python-net/font-replacement/) verandert opzettelijk één lettertype in een ander gedurende de hele presentatie. Lettertype‑substitutie kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde is voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [lettertype‑selectie‑sequentie](/slides/nl/python-net/font-selection-sequence/) tijdens het renderen en converteren. Met `WHEN_INACCESSIBLE` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er wanneer een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te vermijden?**

Ja. U kunt [externe lettertypen laden](/slides/nl/python-net/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distributeert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, dus een lettertype dat op het ene systeem beschikbaar is, kan op een ander systeem substitutie vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertypebestanden en versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/python-net/custom-font/), en [embed lettertypen](/slides/nl/python-net/embedded-font/) indien de licentie dit toestaat. U kunt ook [FontsManager.get_substitutions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/) aanroepen vóór export om onverwachte substituties te identificeren.