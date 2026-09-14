---
title: Beheer script-specifieke thema-lettertypen in Python via Java
linktitle: Script-specifieke themaletters
type: docs
weight: 15
url: /nl/python-java/script-specific-font-mappings/
keywords:
- script-specifiek lettertype
- thema-lettertype-mapping
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
- Java
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script-specifieke lettertype-mappingen in PowerPoint-thema’s met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertype‑gez families selecteren voor verschillende schrijfsystemen. Hierdoor kan meertalige tekst die nog steeds thema‑lettertypen gebruikt, één gecoördineerd lettertype‑schema volgen terwijl er geschikte lettertypen worden gebruikt voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere scripts.

Het [FontScheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontscheme/) van het thema bevat een hoofdlettertype‑collectie, meestal gebruikt voor koppen, en een secundaire lettertype‑collectie, meestal gebruikt voor de hoofdtekst. Naast hun Latin‑ en Oost‑Azië‑lettertype‑instellingen, bieden beide collecties mappingen van schrijfsysteem‑tags naar lettertype‑familienamen via de [Fonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/)‑klasse.

Dit artikel laat zien hoe u die mappingen in het master‑thema van de presentatie kunt inspecteren en aanpassen, en controleren dat de wijzigingen behouden blijven na een opslaan‑en‑herladen‑cyclus.

## **Begrijp Script‑Tags**

De script‑lettertype‑methoden gebruiken vierletterige BCP 47‑script‑subtags om schrijfsystemen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schrijfsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereenvoudigd Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Deze mappingen behoren tot het thema‑lettertype‑schema, niet tot individuele tekstgedeelten. Een presentatie kan verschillende mappingen definiëren voor de hoofd‑ en secundaire collecties, en kan voor sommige scripts geen mapping definiëren.

## **Toegang tot en Inspectie van Script‑Lettertype‑Mappen**

Gebruik [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasterTheme) om het thema op presentatieniveau te benaderen. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontscheme/#getMajor) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontscheme/#getMinor) retourneren respectievelijk de twee [Fonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/)‑collecties.

Roep [Fonts.getScriptFontMap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/#getScriptFontMap) aan om alle mappingen uit een collectie op te halen. Om één schrijfsysteem op te zoeken, roep [Fonts.getScriptFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/#getScriptFont) aan met de bijbehorende script‑tag. `getScriptFont` retourneert `None` wanneer die collectie de gevraagde mapping niet heeft gedefinieerd.

## **Mappen Aanpassen en Volharding Verifiëren**

Gebruik [Fonts.setScriptFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/#setScriptFont) om een mapping te maken of de huidige lettertype‑familie te vervangen. Gebruik [Fonts.removeScriptFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/#removeScriptFont) om een mapping te verwijderen.

Het volgende end‑to‑end‑voorbeeld leest alle bestaande hoofd‑ en secundaire mappingen, zoekt het Japanse hoofdlettertype op, wijzigt het Cyrillische hoofdlettertype, verwijdert de Thaana‑secundaire mapping, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderingsstap onafhankelijk te maken van het initiële thema, maakt het voorbeeld eerst een Thaana‑mapping alleen aan wanneer er nog geen bestaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

De verificatie maakt gebruik van hetzelfde `None`‑gedrag als een gewone lookup: na het opslaan van de verwijdering geeft `getScriptFont("Thaa")` `None` terug voor de secundaire collectie.

## **Verschil Tussen Thema‑Mappen en Andere Lettertype‑Instellingen**

Script‑specifieke thema‑mappen beïnvloeden de lettertype‑selectie, maar lossen een ander probleem op dan directe tekst‑opmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een thema‑mapping |
|---|---|---|
| Script‑specifieke thema‑lettertype‑mapping | Selecteert een hoofd‑ of secundair thema‑lettertype voor een schrijfsysteem. | Tekst die nog steeds het corresponderende thema‑lettertype gebruikt, kan naar de nieuwe mapped familie resolven. |
| Lettertype expliciet toegewezen aan een tekstdeel | Fixeert de gevraagde lettertype‑familie voor dat deel in plaats van te vertrouwen op het thema. | Het deel blijft mogelijk ongewijzigd omdat de directe opmaak de themakeuze overstemt. |
| Lettertype‑substitutie | Vervangt een gevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is aangevraagd; het herdefinieert de script‑mapping van het thema niet. |
| Lettertype‑fallback | Levert glyphs die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende glyph‑dekking aan; het verandert de opgeslagen thema‑mapping niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/python-java/font-substitution/) en [Fallback Fonts](/slides/nl/python-java/fallback-font/).

Het wijzigen van een mapping in [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getMasterTheme) heeft alleen invloed op inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een thema‑override erven van een master, lay‑out of dia, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet de mapping op presentatieniveau volgt.

## **Mapped Lettertypen Beschikbaar Maken en het Resultaat Valideren**

Een script‑mapping slaat een lettertype‑familienaam op; het installeert of laadt het overeenkomstige lettertype‑bestand niet. Voor consistente weergave en export moet elk gemapt lettertype geïnstalleerd zijn in de omgeving of worden geleverd aan Aspose.Slides via een aangepaste bron zoals [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadExternalFonts) of [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Zie [Custom Fonts](/slides/nl/python-java/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen mapping bevestigt alleen dat de thema‑definitie behouden is gebleven. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste glyphs bevat, of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schrijfsysteem naar een afbeelding of PDF en inspecteer de uitvoer. Dit ontdekt ontbrekende lettertypen, onvolledige glyph‑dekking, fallback‑gedrag en layout‑veranderingen voordat de presentatie wordt verspreid. Zie [Convert PowerPoint Presentations](/slides/nl/python-java/convert-powerpoint/) voor render‑ en export‑voorbeelden.

## **FAQ**

**Wat retourneert `getScriptFont` wanneer een script niet gemapt is?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/#getScriptFont) retourneert `None` wanneer de gevraagde script‑mapping niet gedefinieerd is in die hoofd‑ of secundaire lettertype‑collectie.

**Voegt `setScriptFont` een tweede mapping toe wanneer het script al bestaat?**

Nee. [Fonts.setScriptFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fonts/#setScriptFont) maakt de mapping aan wanneer deze ontbreekt en vervangt de gemapte lettertype‑familie wanneer dezelfde script‑tag al aanwezig is.

**Waarom wijzigde het aanpassen van een thema‑mapping niet sommige teksten?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een override, of beïnvloed worden door substitutie of fallback tijdens het renderen. Een script‑mapping op presentatieniveau regelt alleen tekst waarvan de effectieve opmaak nog steeds naar die thema‑lettertype‑collectie verwijst.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Heropenen verifieert de volharding van de themagegevens. Render ook representatieve tekst van elk vereist schrijfsysteem om te bevestigen dat de gemapte lettertypen beschikbaar zijn en de benodigde glyphs bevatten.