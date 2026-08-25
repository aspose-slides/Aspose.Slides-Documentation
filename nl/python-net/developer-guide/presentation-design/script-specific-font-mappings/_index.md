---
title: Beheer script‑specifieke themalettertypen in Python
linktitle: Script‑specifieke themalettertypen
type: docs
weight: 15
url: /nl/python-net/script-specific-font-mappings/
keywords:
- script‑specifiek lettertype
- themalettertype mapping
- meertalige presentatie
- schrijfsysteem
- Cyrillisch lettertype
- Arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana lettertype
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script‑specifieke lettertype‑mappings in PowerPoint‑thema's met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertypefamilies selecteren voor verschillende schrijfsystemen. Hierdoor kan meertalige tekst die nog steeds thema‑lettertypen gebruikt, één gecoördineerd lettertype‑schema volgen terwijl geschikte lettertypen worden gebruikt voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere scripts.

Het [FontScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/) van het thema bevat een hoofd‑lettertypecollectie, meestal gebruikt voor koppen, en een secundaire lettertypecollectie, meestal gebruikt voor de hoofdtekst. Naast hun Latijnse en Oost‑Azia‑lettertype‑eigenschappen bieden beide collecties mappings van schrijfsysteem‑tags naar lettertype‑familienamen via de klasse [Fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/).

Dit artikel toont hoe u die mappings in het master‑thema van de presentatie kunt inspecteren en wijzigen en verifiëren dat de veranderingen een opslaan‑en‑herladen‑cyclus overleven.

## **Script‑tags begrijpen**

De methoden voor script‑lettertypen gebruiken vierletterige BCP 47 script‑subtags om schrijfsystemen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schrijfsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Versimpeld Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Deze mappings behoren tot het thema‑lettertype‑schema, niet tot individuele tekstgedeelten. Een presentatie kan verschillende mappings definiëren voor de hoofd‑ en secundaire collecties, en kan mappings weglaten voor bepaalde scripts.

## **Toegang tot en inspectie van scriptlettertype‑mappings**

Gebruik [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) om toegang te krijgen tot het thema op presentatieniveau. De eigenschappen [FontScheme.major](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/major/) en [FontScheme.minor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/minor/) geven de twee [Fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/)‑collecties terug.

Roep [Fonts.get_script_font_map](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/get_script_font_map/) aan om alle mappings uit een collectie op te halen. Om één schrijfsysteem op te zoeken, roep [Fonts.get_script_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/get_script_font/) aan met de bijbehorende script‑tag. `get_script_font` retourneert `None` wanneer die collectie de gevraagde mapping niet heeft gedefinieerd.

## **Mappings wijzigen en persistentie verifiëren**

Gebruik [Fonts.set_script_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/set_script_font/) om een mapping te maken of de huidige lettertypefamilie te vervangen. Gebruik [Fonts.remove_script_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/remove_script_font/) om een mapping te verwijderen.

Het volgende end‑to‑end‑voorbeeld leest alle bestaande hoofd‑ en secundaire mappings, zoekt het Japanse hoofd‑lettertype op, wijzigt het Cyrillische hoofd‑lettertype, verwijdert de Thaana‑secundaire mapping, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderingsstap onafhankelijk van het initiële thema te maken, creëert het voorbeeld eerst een Thaana‑mapping alleen wanneer er nog geen is gedefinieerd.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

De verificatie maakt gebruik van hetzelfde `None`‑gedrag als een gewone lookup: na het opslaan van de verwijdering geeft `get_script_font("Thaa")` `None` terug voor de secundaire collectie.

## **Thema‑mappings onderscheiden van andere lettertype‑instellingen**

Script‑specifieke themamappings nemen deel aan de lettertype‑selectie, maar lossen een ander probleem op dan directe tekstformattering, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themamapping |
|---|---|---|
| Script‑specifieke themamapping van lettertype | Selecteert een hoofd‑ of secundair themalettertype voor een schrijfsysteem. | Tekst die nog steeds het overeenkomende themalettertype gebruikt, kan zich aanpassen naar de nieuw gemapte familie. |
| Lettertype expliciet toegewezen aan een tekstgedeelte | Fixeert de gevraagde lettertypefamilie voor dat gedeelte in plaats van te vertrouwen op het thema. | Het gedeelte blijft mogelijk ongewijzigd omdat directe opmaak het themakeuze overschrijft. |
| Lettertype‑substitutie | Vervangt een gevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is opgegeven; het herdefinieert de script‑mapping van het thema niet. |
| Lettertype‑fallback | Levert glyphs die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende glyph‑dekking; het wijzigt de opgeslagen themamapping niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/python-net/font-substitution/) en [Fallback Fonts](/slides/nl/python-net/fallback-font/).

Het wijzigen van een mapping in [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) heeft alleen invloed op inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een themaverererving van een master, layout of dia overerven, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de mapping op presentatieniveau.

## **Gemapte lettertypen beschikbaar maken en het resultaat valideren**

Een script‑mapping slaat een lettertypefamilienaam op; het installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk gemapt lettertype geïnstalleerd zijn in de omgeving of beschikbaar worden gesteld aan Aspose.Slides via een aangepaste bron, zoals [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/load_external_fonts/) of [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/document_level_font_sources/). Zie [Custom Fonts](/slides/nl/python-net/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen mapping bevestigt alleen dat de themadefinitie behouden bleef. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste glyphs bevat of de beoogde lay‑out produceert. Render representatieve tekst voor elk vereist schrijfsysteem naar een afbeelding of PDF en inspecteer de output. Dit detecteert ontbrekende lettertypen, onvolledige glyph‑dekking, fallback‑gedrag en lay‑outwijzigingen voordat de presentatie wordt verspreid. Zie [Convert PowerPoint Presentations](/slides/nl/python-net/convert-powerpoint/) voor render‑ en exportvoorbeelden.

## **FAQ**

**Wat retourneert `get_script_font` wanneer een script niet gemapt is?**

[Fonts.get_script_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/get_script_font/) retourneert `None` wanneer de gevraagde script‑mapping niet is gedefinieerd in die hoofd‑ of secundaire lettertypecollectie.

**Voegt `set_script_font` een tweede mapping toe wanneer het script al bestaat?**

Nee. [Fonts.set_script_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fonts/set_script_font/) maakt de mapping aan wanneer deze ontbreekt en vervangt de gemapte lettertypefamilie wanneer dezelfde script‑tag al aanwezig is.

**Waarom veranderde het aanpassen van een themamapping niet de opmaak van sommige tekst?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een override, of beïnvloed worden door substitutie of fallback tijdens het renderen. Een script‑mapping op presentatieniveau regelt alleen tekst waarvan de effectieve opmaak nog steeds verwijst naar die themalettertype‑collectie.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Het opnieuw openen verifieert alleen de persistentie van de themagegevens. Render ook representatieve tekst uit elk vereist schrijfsysteem om te bevestigen dat de gemapte lettertypen beschikbaar zijn en de nodige glyphs bevatten.