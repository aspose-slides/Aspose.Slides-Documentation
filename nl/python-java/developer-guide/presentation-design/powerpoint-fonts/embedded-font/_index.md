---
title: "Lettertypen insluiten in presentaties in Python via Java"
linktitle: "Ingesloten lettertypen"
type: docs
weight: 40
url: /nl/python-java/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- lettertype insluiten
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor Python via Java. Voeg toe, haal op, verwijder en comprimeer lettertypen om de weergave van tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Inleiding**

Lettertypen insluiten slaat lettertypegegevens op in een PowerPoint-presentatie. Wanneer een viewer ingesloten lettertypen ondersteunt, kan deze tekst weergeven met die lettertypen, zelfs als ze niet op het doelsysteem geïnstalleerd zijn. Dit helpt om regeleinden, tekstruimte en de lay-out van de dia te behouden.

Aspose.Slides for Python via Java stelt u in staat om ingesloten lettertypen op te halen, toe te voegen en te verwijderen via de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) klasse die wordt geretourneerd door [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getFontsManager). U kunt ook de grootte van ingesloten lettertypegegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De onderstaande voorbeelden werken met PPTX-bestanden. Voordat u een lettertype insluit, moet u ervoor zorgen dat de lettertypegegevens beschikbaar zijn voor Aspose.Slides en dat de licentie van het lettertype insluiten toestaat.

## **Ingesloten lettertypen ophalen en verwijderen**

Gebruik [getEmbeddedFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) om de lettertypen die in een presentatie zijn opgeslagen te tonen. Om er één te verwijderen, geeft u een lettertype uit die lijst door aan [removeEmbeddedFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), en slaat vervolgens de presentatie op.

Het volgende voorbeeld geeft een lijst weer van de ingesloten lettertypen in `EmbeddedFonts.pptx` en verwijdert Calibri als die aanwezig is:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Het verwijderen van een ingesloten lettertype verwijdert de opgeslagen lettertypegegevens; het wijzigt niet het aan de tekst toegewezen lettertype. Als het lettertype op het doelsysteem geïnstalleerd is, kan de tekst het nog steeds gebruiken. Anders kan weergave een lettertype‑substitutie vereisen, wat de lay‑out kan beïnvloeden.

## **Lettertypegegevens en insluitrechten inspecteren**

Gebruik de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) klasse om lettertypen te inspecteren voordat ze worden ingesloten. Roep [FontsManager.getFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getFonts) aan om de lettertypen op te halen die in de presentatie worden gebruikt. Voor elk lettertype geeft u een [FontData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontdata/) object en de vereiste [FontStyleType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontstyletype/) waarde door aan [FontsManager.getFontBytes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getFontBytes). De methode retourneert de binaire gegevens voor die lettertype‑stijl, of `None` wanneer het gevraagde lettertype of de stijl niet beschikbaar is. Geef geen `None`-resultaat door aan [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), omdat die methode een byte‑array vereist.

`EmbeddingLevel` is een vlag‑enumeratie die de insluitbeperkingen rapporteert die in het lettertype zijn opgeslagen:
- `Installable` staat toe dat het lettertype wordt ingesloten en permanent wordt geïnstalleerd op een ander systeem, onder voorbehoud van de licentie van het lettertype.
- `Restricted` verbiedt insluiten tenzij toestemming is verkregen van de juridische eigenaar van het lettertype wanneer dit de enige gebruiks‑toestemming vlag is.
- `PreviewPrint` staat tijdelijk gebruik voor bekijken en afdrukken toe; een document dat het lettertype bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een extra beperking die het insluiten van slechts een subset van de tekens verbiedt. Wanneer deze vlag aanwezig is, worden alle tekens ingesloten.
- `BitmapOnly` is een extra beperking die alleen bitmap‑strikes toelaat om in te sluiten, niet de contour‑data. Als het lettertype geen bitmap‑strikes heeft, kan het niet worden ingesloten.

De eerste vier waarden beschrijven de gebruikstoestemming, terwijl `NoSubsetting` en `BitmapOnly` ermee gecombineerd kunnen worden. Controleer de modificatoren met bitwise‑operaties. Omdat `Installable` nul is, maskert u de gebruikstoestemmingsbits en vergelijkt u het resultaat met `Installable` in plaats van het te controleren als een vlag. Huidige lettertypen zouden maximaal één gebruikstoestemmingsbit moeten instellen. Voor compatibiliteit met oudere lettertypen die meer dan één bit instellen, kiest de onderstaande helper de minst beperkende toestemming: `Editable`, vervolgens `PreviewPrint`, vervolgens `Restricted`.

Het volgende voorbeeld controleert de reguliere, vet, cursief en vet‑cursief gegevens die beschikbaar zijn voor elk lettertype dat door `getFonts` wordt geretourneerd. Het slaat niet‑beschikbare stijlen, beperkte lettertypen, alleen‑bitmap‑lettertypen, lettertypen beperkt tot preview en print (omdat de uitvoer bewerkbaar blijft), en lettertypen die al zijn ingesloten over. Als een beschikbare stijl `NoSubsetting` heeft, worden alle tekens voor die lettertype‑familie ingesloten.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Deze inspectie rapporteert de beperkingen die in elk lettertype‑bestand zijn gecodeerd. Het verleent geen licentie, bewijst niet dat u het lettertype legaal hebt verkregen, en vervangt niet de controle van de licentieovereenkomst van het lettertype voordat u een ingesloten kopie verspreidt.

## **Ingesloten lettertypen toevoegen**

Gebruik [addEmbeddedFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) om een lettertype in te sluiten. De overloads accepteren ofwel een [FontData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontdata/) object of een byte‑array met de lettertype‑gegevens. De [EmbedFontCharacters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/embedfontcharacters/) enumeratie bepaalt welke tekens worden opgenomen:
- [All](https://reference.aspose.com/slides/nl/python-java/aspose.slides/embedfontcharacters/) sluit alle tekens in het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- [OnlyUsed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/embedfontcharacters/) sluit alleen de tekens in die in de presentatie worden gebruikt om de bestandsgrootte te verkleinen. Kies deze optie voor een afgewerkte presentatie die voornamelijk bedoeld is voor weergave.

Het volgende voorbeeld gebruikt [getFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getFonts) om de lettertypen op te halen die worden gebruikt in `Fonts.pptx` en sluit die in die nog niet zijn ingesloten. De toe te voegen lettertypen moeten beschikbaar zijn op de machine waarop de code wordt uitgevoerd. Bestaande ingesloten lettertypen behouden hun huidige tekensets.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ingesloten lettertypen comprimeren**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#compressEmbeddedFonts) verkleint ingesloten lettertypegegevens door ongebruikte tekens te verwijderen. Het werkt op lettertypen die al zijn ingesloten, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertypegegevens de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Houd het originele bestand behouden als ontvangers later tekst moeten toevoegen. Tekens die tijdens compressie zijn verwijderd, zijn niet meer beschikbaar vanuit het ingesloten lettertype, zelfs als u oorspronkelijk alle tekens had ingesloten.

## **FAQ**

**Hoe kan ik controleren of een ingesloten lettertype nog steeds wordt vervangen tijdens het renderen?**

Roep [getSubstitutions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions) aan in de omgeving waarin u de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor lettertype‑substitutie en de fallback‑regels voor lettertypen. Fallback behandelt ontbrekende tekens, dus het insluiten van een lettertype lost geen tekens op die het lettertype zelf niet bevat.

**Moet ik veelgebruikte lettertypen zoals Arial en Calibri insluiten?**

Bepaal de beslissing op basis van de doenomgeving. Als de benodigde lettertypen beschikbaar zijn op elke machine die de presentatie opent of rendert, kan het insluiten ervan overbodige bestandsgrootte toevoegen. Als ontvangers of servers die lettertypen mogelijk niet hebben, kan het insluiten ervan helpen de beoogde weergave te behouden, mits hun licenties dit toestaan.