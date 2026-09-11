---
title: Aangepaste PowerPoint-lettertypen in Python via Java
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/python-java/custom-font/
keywords:
- lettertype
- aangepast lettertype
- extern lettertype
- lettertype laden
- lettertypen beheren
- lettertype map
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas lettertypen aan in PowerPoint-dia’s met Aspose.Slides voor Python via Java om je presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides stelt je in staat aangepaste lettertypen te gebruiken in presentaties zonder ze op het besturingssysteem te installeren. Je kunt lettertypen laden vanuit aangepaste mappen, lettertypen voor een specifieke presentatie leveren via document‑niveau fontbronnen, of externe lettertypen direct laden vanuit binaire gegevens.

Geladen lettertypen worden gebruikt wanneer een presentatie wordt gerenderd of geëxporteerd, bijvoorbeeld naar PDF, afbeeldingen en andere ondersteunde formaten. Dit helpt de uitvoer van de presentatie consistent te houden over verschillende omgevingen. Het artikel legt ook uit hoe je de door Aspose.Slides gebruikte lettertype‑mappen kunt inspecteren en hoe je de lettertype‑cache kunt wissen na het werken met externe lettertypen.

Het registreren van aangepaste lettertypen voor weergave is gescheiden van het insluiten van lettertypen in een PPTX‑bestand. Als een lettertype moet worden opgeslagen binnen de presentatie zelf, gebruik dan expliciet de functies voor lettertype‑insluiting.

Een presentatiethema kan verschillende lettertypefamilies refereren voor afzonderlijke schrijfsystemen. Deze koppelingen slaan lettertype‑namen op maar installeren of laden de lettertype‑bestanden niet. Zie [Script‑specifieke themalettertypen](/slides/nl/python-java/script-specific-font-mappings/) om de koppelingen te beheren, en gebruik de onderstaande laadopties om de gerefereerde lettertypen beschikbaar te maken voor consistente weergave.

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides stelt je in staat deze lettertypen te laden met de [loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadExternalFonts)‑methode:

* TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Aangepaste lettertypen laden**

Aspose.Slides stelt je in staat de in een presentatie gebruikte lettertypen te laden zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de resulterende documenten er consistent uitzien over omgevingen heen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef een of meer mappen op die de lettertypebestanden bevatten.
2. Roep de statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadExternalFonts)‑methode aan om lettertypen uit die mappen te laden.
3. Laad en rendereer/exporteer de presentatie.
4. Roep [FontsLoader.clearCache](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#clearCache) aan om de lettertype‑cache te wissen.

Het volgende codevoorbeeld toont het proces van het laden van lettertypen:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Definieer mappen die aangepaste lettertypebestanden bevatten.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Laad aangepaste lettertypen vanuit de opgegeven mappen.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Render/exports de presentatie met de geladen lettertypen.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Wis de lettertypecache nadat het werk voltooid is.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Opmerking" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadExternalFonts) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert de initialiseringsvolgorde van lettertypen niet.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaardlettertypepad van het besturingssysteem.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/) zijn geladen.

{{%/alert %}}

## **Aangepaste lettertype‑mappen ophalen**
Aspose.Slides biedt de [getFontFolders](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#getFontFolders)‑methode om je in staat te stellen lettertype‑mappen te vinden. Deze methode retourneert mappen die zijn toegevoegd via de [loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadExternalFonts)‑methode en systeem‑lettertype‑mappen.

Deze Python‑code laat zien hoe je [getFontFolders](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#getFontFolders) gebruikt:

```python
from asposeslides.api import FontsLoader

# Haal mappen op die zijn toegevoegd via loadExternalFonts en systeemlettertype-mappen.
font_folders = FontsLoader.getFontFolders()
```

## **Aangepaste lettertypen specificeren die met een presentatie worden gebruikt**
Aspose.Slides biedt de [getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)‑methode om externe lettertypen te specificeren die met de presentatie worden gebruikt.

Deze Python‑code laat zien hoe je de [getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)‑methode gebruikt:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Werk met de presentatie.
    # CustomFont1, CustomFont2 en lettertypen van assets/fonts en global/fonts
    # en hun submappen zijn beschikbaar voor de presentatie.
    pass
finally:
    presentation.dispose()
```

## **Lettertypen extern beheren**

Aspose.Slides biedt de [loadExternalFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadExternalFont)‑methode om externe lettertypen uit binaire gegevens te laden.

Deze Python‑code toont het proces van het laden van een lettertype uit een byte‑array:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Externe lettertypen worden geladen tijdens de levensduur van de presentatie.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Beïnvloeden aangepaste lettertypen de export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?**

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als je het lettertype in het presentatie‑bestand wilt opnemen, moet je de expliciete [insluitingsfuncties](/slides/nl/python-java/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyphs mist?**

Ja. Configureer [font substitution](/slides/nl/python-java/font-substitution/), [vervangingsregels](/slides/nl/python-java/font-replacement/) en [fallback‑sets](/slides/nl/python-java/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyph ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeem‑wijd te installeren?**

Ja. Verwijs naar je eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeembrede lettertype‑directories in de container‑image.

**Hoe zit het met licenties — mag ik elk aangepast lettertype zonder beperkingen insluiten?**

Je bent zelf verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden variëren; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat je resultaten distribueert.