---
title: PowerPoint-lettertypen aanpassen in Python
linktitle: Aangepast lettertype
type: docs
weight: 20
url: /nl/python-net/custom-font/
keywords:
- lettertype
- aangepast lettertype
- extern lettertype
- lettertype laden
- lettertypen beheren
- lettertype map
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Integreer aangepaste lettertypen in PowerPoint-dia's met Aspose.Slides voor Python via .NET om uw presentaties scherp en consistent te houden op elk apparaat."
---
## **Overzicht**

Aspose.Slides for Python maakt het mogelijk om tijdens runtime aangepaste lettertypen te leveren zodat presentaties correct worden weergegeven, zelfs wanneer de vereiste lettertypen niet op het host‑systeem zijn geïnstalleerd. Bij het exporteren naar PDF of afbeeldingen kun je lettertype‑mappen of lettertype‑gegevens in het geheugen opgeven om de tekstlay‑out, glyf‑metriek en typografie te behouden. Dit zorgt voor voorspelbare server‑side rendering in verschillende omgevingen, verwijdert OS‑niveau afhankelijkheden van lettertypen en voorkomt ongewenste fallback‑ of reflow‑situaties. In dit artikel wordt getoond hoe je lettertype‑bronnen registreert.

Een presentatie‑thema kan verschillende lettertype‑families refereren voor afzonderlijke schrijfsystemen. Deze toewijzingen slaan alleen de lettertype‑namen op, maar installeren of laden de lettertype‑bestanden niet. Zie [Script‑specifieke thema‑lettertypen](/slides/nl/python-net/script-specific-font-mappings/) om de toewijzingen te beheren, en gebruik de onderstaande laad‑opties om de refererende lettertypen beschikbaar te maken voor consistente weergave.

Aspose.Slides laat je de volgende lettertypen laden met de methoden `load_external_font` en `load_external_fonts` van de [FontsLoader](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/)‑klasse:

- TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Aangepaste lettertypen laden**

Aspose.Slides stelt je in staat om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de export‑output — zoals PDF, afbeeldingen en andere ondersteunde formaten — zodat de gegenereerde documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meerdere mappen op die de lettertype‑bestanden bevatten.
2. Roep de statische [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/load_external_fonts/)‑methode aan om lettertypen uit die mappen te laden.
3. Laad en render/exporteer de presentatie.
4. Roep [FontsLoader.clear_cache](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/clear_cache/) aan om de lettertype‑cache te wissen.

Het volgende codevoorbeeld toont het lettertype‑laadproces:

```py
import aspose.slides as slides

# Definieer de mappen die aangepaste lettertype-bestanden bevatten.
font_folders = ["fonts", "external_fonts"]

# Laad aangepaste lettertypen vanuit de opgegeven mappen.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Wis de lettertype-cache nadat het werk is voltooid.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Opmerking" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/load_external_fonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de initialisatie‑volgorde van de lettertypen.
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaard besturingssysteem‑lettertypepad.
1. De paden die via [FontsLoader](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/) zijn geladen.
{{%/alert %}}

## **De map met aangepaste lettertypen ophalen**

Aspose.Slides biedt de methode `get_font_folders` om lettertype‑mappen op te halen. Deze geeft zowel de via `load_external_fonts` toegevoegde mappen als de systeem‑lettertype‑mappen terug.

Deze Python‑code laat zien hoe `get_font_folders` wordt gebruikt:

```python
import aspose.slides as slides

# Deze oproep geeft de mappen terug die gecontroleerd worden op lettertypebestanden.
# Deze omvatten de mappen die via de load_external_fonts-methode zijn toegevoegd en de systeem-lettertype-mappen.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Aangepaste lettertypen voor een presentatie opgeven**

Aspose.Slides biedt de eigenschap `document_level_font_sources`, waarmee je externe lettertypen kunt specificeren die bij een presentatie gebruikt moeten worden.

Het volgende Python‑voorbeeld laat zien hoe `document_level_font_sources` wordt gebruikt:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Werk met de presentatie.
    # CustomFont1, CustomFont2 en lettertypen uit de mappen assets\fonts en global\fonts (en hun submappen) zijn beschikbaar voor de presentatie.
    # ...
    print(len(presentation.slides))
```

## **Externe lettertypen laden vanuit binaire gegevens**

Aspose.Slides biedt de methode `load_external_font` om externe lettertypen te laden vanuit binaire gegevens.

Het volgende Python‑voorbeeld demonstreert het laden van een lettertype vanuit een byte‑array:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Laad externe lettertypen vanuit byte-arrays.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externe lettertypen zijn beschikbaar gedurende de levensduur van deze presentatiewinstantie.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### Heeft het gebruik van aangepaste lettertypen invloed op de export naar alle formaten (PDF, PNG, SVG, HTML)?

Ja. Verbonden lettertypen worden door de renderer gebruikt voor alle export‑formaten.

### Worden aangepaste lettertypen automatisch ingebed in de resulterende PPTX?

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als je het lettertype in het presentatie‑bestand wilt opnemen, moet je de expliciete [embed‑functies](/slides/nl/python-net/embedded-font/) gebruiken.

### Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyfen mist?

Ja. Configureer [font substitution](/slides/nl/python-net/font-substitution/), [replacement rules](/slides/nl/python-net/font-replacement/) en [fallback sets](/slides/nl/python-net/fallback-font/) om precies te definiëren welk lettertype wordt gebruikt wanneer het gevraagde glyf ontbreekt.

### Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeemwijd te installeren?

Ja. Verwijs naar je eigen lettertype‑mappen of laad lettertypen vanuit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeembrede lettertype‑directories in het container‑image.

### Hoe zit het met licenties — kan ik elk aangepast lettertype insluiten zonder beperkingen?

Jij bent verantwoordelijk voor naleving van de licentievoorwaarden van het lettertype. De voorwaarden verschillen; sommige licenties verbieden insluiten of commercieel gebruik. Controleer altijd de EULA van het lettertype vóór distributie van de output.