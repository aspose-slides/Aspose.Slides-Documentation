---
title: Aangepaste PowerPoint-lettertypen in Python
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
description: "Integreer aangepaste lettertypen in PowerPoint-dia's met Aspose.Slides voor Python via .NET, zodat je presentaties scherp en consistent blijven op elk apparaat."
---
## **Overzicht**

Aspose.Slides voor Python stelt je in staat om aangepaste lettertypen op runtime te leveren zodat presentaties correct worden weergegeven, zelfs wanneer de vereiste lettertypen niet op het systeem zijn geïnstalleerd. Bij het exporteren naar PDF of afbeeldingen kun je lettertypefolders of lettertype‑gegevens in het geheugen opgeven om de tekstlay-out, glyfmetriek en typografie te behouden. Dit maakt server‑side rendering voorspelbaar in verschillende omgevingen, verwijdert OS‑afhankelijke lettertype‑afhankelijkheden en voorkomt ongewenste fallback‑ of herindelingen. In dit artikel wordt getoond hoe je lettertypebronnen kunt registreren.

Aspose.Slides laat je de volgende lettertypen laden met de `load_external_font` en `load_external_fonts` methoden van de [FontsLoader](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/) klasse:

- TrueType (.ttf) en TrueType Collection (.ttc) lettertypen. Zie [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) lettertypen. Zie [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Aangepaste Lettertypen Laden**

Aspose.Slides maakt het mogelijk om lettertypen die in een presentatie worden gebruikt te laden zonder ze op het systeem te installeren. Dit beïnvloedt de exportoutput – zoals PDF, afbeeldingen en andere ondersteunde formaten – zodat de gegenereerde documenten er consistent uitzien in verschillende omgevingen. Lettertypen worden geladen vanuit aangepaste mappen.

1. Geef één of meer mappen op die de lettertypebestanden bevatten.  
2. Roep de statische [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/load_external_fonts/) methode aan om lettertypen uit die mappen te laden.  
3. Laad en render/​export de presentatie.  
4. Roep [FontsLoader.clear_cache](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/clear_cache/) aan om de lettertype‑cache te wissen.

Het volgende code‑voorbeeld toont het proces van het laden van lettertypen:

```py
import aspose.slides as slides

# Definieer mappen die aangepaste lettertypebestanden bevatten.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Laad aangepaste lettertypen uit de opgegeven mappen.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/exporteer de presentatie (bijv. naar PDF, afbeeldingen of andere formaten) met de geladen lettertypen.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Wis de lettertype-cache nadat het werk voltooid is.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/load_external_fonts/) voegt extra mappen toe aan de zoekpaden voor lettertypen, maar verandert niet de volgorde waarin lettertypen worden geïnitialiseerd.  
Lettertypen worden in deze volgorde geïnitialiseerd:

1. Het standaardpad van het besturingssysteem voor lettertypen.  
1. De paden die zijn geladen via [FontsLoader](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/).  
{{%/alert %}}

## **De Aangepaste Lettertypenmap Opvragen**

Aspose.Slides biedt de `get_font_folders` methode om lettertype‑mappen op te halen. Deze retourneert zowel de mappen die via `load_external_fonts` zijn toegevoegd als de systeem‑lettertype‑mappen.

Deze Python‑code laat zien hoe `get_font_folders` wordt gebruikt:

```python
import aspose.slides as slides

# Deze oproep geeft de mappen terug die gecontroleerd worden op lettertypebestanden.
# Deze omvatten mappen die zijn toegevoegd via de load_external_fonts-methode en de systeem-lettertype-mappen.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Aangepaste Lettertypen Opgeven Voor Een Presentatie**

Aspose.Slides biedt de `document_level_font_sources` eigenschap, waarmee je externe lettertypen kunt opgeven die bij een presentatie moeten worden gebruikt.

Het volgende Python‑voorbeeld toont het gebruik van `document_level_font_sources`:

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
    # CustomFont1, CustomFont2, en lettertypen uit de assets\fonts en global\fonts mappen (en hun submappen) zijn beschikbaar voor de presentatie.
    # ...
    print(len(presentation.slides))
```

## **Externe Lettertypen Laden Vanuit Binaire Gegevens**

Aspose.Slides biedt de `load_external_font` methode om externe lettertypen uit binaire gegevens te laden.

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
        # Externe lettertypen zijn beschikbaar gedurende de levensduur van deze presentatie-instansie.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

**Hebben aangepaste lettertypen invloed op de export naar alle formaten (PDF, PNG, SVG, HTML)?**

Ja. Gekoppelde lettertypen worden door de renderer gebruikt voor alle exportformaten.

**Worden aangepaste lettertypen automatisch ingesloten in de resulterende PPTX?**

Nee. Een lettertype registreren voor weergave is niet hetzelfde als het insluiten in een PPTX. Als je het lettertype wilt opnemen in het presentatie‑bestand, moet je de expliciete [embedfuncties](/slides/nl/python-net/embedded-font/) gebruiken.

**Kan ik het fallback‑gedrag regelen wanneer een aangepast lettertype bepaalde glyfen mist?**

Ja. Configureer [fontersubstitutie](/slides/nl/python-net/font-substitution/), [vervangingsregels](/slides/nl/python-net/font-replacement/) en [fallback‑sets](/slides/nl/python-net/fallback-font/) om precies te bepalen welk lettertype wordt gebruikt wanneer de gevraagde glyf ontbreekt.

**Kan ik lettertypen gebruiken in Linux/Docker‑containers zonder ze systeem‑wijd te installeren?**

Ja. Verwijs naar je eigen lettertype‑mappen of laad lettertypen uit byte‑arrays. Dit verwijdert elke afhankelijkheid van systeem‑lettertype‑mappen in het container‑image.

**Hoe zit het met licenties – kan ik elk aangepast lettertype zonder beperkingen insluiten?**

Je bent zelf verantwoordelijk voor de naleving van de lettertype‑licenties. De voorwaarden variëren; sommige licenties verbieden insluiting of commercieel gebruik. Controleer altijd de EULA van het lettertype voordat je de output distribueert.