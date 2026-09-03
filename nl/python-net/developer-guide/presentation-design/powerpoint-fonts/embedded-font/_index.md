---
title: Ingesloten lettertypen in presentaties met Python
linktitle: Ingesloten lettertypen
type: docs
weight: 40
url: /nl/python-net/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor Python via .NET. Gebruik Python om lettertypen toe te voegen, op te halen, te verwijderen en te comprimeren om de weergave van tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Inleiding**

Embedded fonts slaan lettertype‑gegevens op in een PowerPoint‑presentatie. Wanneer een viewer embedded fonts ondersteunt, kan hij de tekst weergeven met die lettertypen, zelfs als ze niet op het doelsysteem zijn geïnstalleerd. Dit helpt om regeleinden, tekstafstanden en de lay‑out van dia’s te behouden.

Aspose.Slides for Python via .NET laat je embedded fonts ophalen, toevoegen en verwijderen via de [fonts_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/fonts_manager/)‑eigenschap van een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object. Je kunt ook de grootte van de embedded lettertype‑gegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De voorbeelden hieronder werken met PPTX‑bestanden. Zorg er vóór het embedden van een lettertype voor dat de lettertype‑gegevens beschikbaar zijn voor Aspose.Slides en dat de licentie van het lettertype embedden toestaat.

## **Lettertypen ophalen en verwijderen**

Gebruik [get_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) om de lettertypen die in een presentatie zijn opgeslagen op te sommen. Om er één te verwijderen, geef een lettertype uit die lijst door aan [remove_embedded_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/remove_embedded_font/), en sla vervolgens de presentatie op.

Het volgende voorbeeld somt de embedded fonts op in `EmbeddedFonts.pptx` en verwijdert Calibri als het aanwezig is:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Het verwijderen van een embedded font verwijdert de opgeslagen lettertype‑gegevens; het verandert niet het lettertype dat aan de tekst is toegewezen. Als het lettertype op het doelsysteem geïnstalleerd is, kan de tekst het nog steeds gebruiken. Anders kan het renderen een [font substitution](/slides/nl/python-net/font-substitution/) vereisen, wat de lay‑out kan beïnvloeden.

## **Lettertypegegevens en insluitrechten inspecteren**

Gebruik de [FontsManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/)‑klasse om lettertypen te inspecteren vóór het embedden. Roep [get_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_fonts/) aan om de lettertypen op te halen die in de presentatie worden gebruikt. Voor elk lettertype geef je een [FontData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontdata/)‑object en de vereiste [FontStyleType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontstyletype/)‑waarde door aan [get_font_bytes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_font_bytes/). De methode geeft de binaire gegevens van die lettertype‑stijl terug, of `None` wanneer het gevraagde lettertype of de stijl niet beschikbaar is. Geef geen `None`‑resultaat door aan [get_font_embedding_level](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), want die methode vereist een byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/nl/python-net/aspose.slides/embeddinglevel/) is een flags‑enumeratie die de insluitbeperkingen in het lettertype rapporteert:

- `INSTALLABLE` staat embedden en permanente installatie op een ander systeem toe, onder voorbehoud van de licentie van het lettertype.
- `RESTRICTED` staat embedden niet toe tenzij toestemming is verkregen van de rechtmatige eigenaar van het lettertype wanneer dit de enige usage‑permission‑flag is.
- `PREVIEW_PRINT` staat tijdelijk gebruik toe voor bekijken en afdrukken; een document dat het lettertype bevat, moet alleen‑lezen zijn.
- `EDITABLE` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NO_SUBSETTING` is een extra beperking die voorkomt dat alleen een subset van de glyphs wordt ingesloten. Als deze flag aanwezig is, moeten alle tekens worden ingesloten.
- `BITMAP_ONLY` is een extra beperking die alleen bitmap‑strikes toestaat om in te sluiten, geen outline‑data. Als het lettertype geen bitmap‑strikes heeft, kan het niet worden ingesloten.

De eerste vier waarden beschrijven het gebruiks‑toestemming, terwijl `NO_SUBSETTING` en `BITMAP_ONLY` ermee gecombineerd kunnen worden. Controleer de modifiers met bitwise‑operaties. Omdat `INSTALLABLE` nul is, maskeer je de usage‑permission‑bits en vergelijk je het resultaat met `INSTALLABLE`. Huidige lettertypen mogen maximaal één usage‑permission‑bit hebben. Voor compatibiliteit met oudere lettertypen die meer dan één hebben, selecteert de hulpfunctie hieronder de minst beperkende permissie: `EDITABLE`, dan `PREVIEW_PRINT`, dan `RESTRICTED`.

Het volgende voorbeeld controleert de reguliere, vet, cursief en vet‑cursief data die beschikbaar zijn voor elk lettertype dat door `get_fonts` wordt geretourneerd. Het slaat niet‑beschikbare stijlen over, beperktere lettertypen, alleen‑bitmap‑lettertypen, lettertypen die alleen voor preview en print zijn beperkt omdat de output bewerkbaar blijft, en lettertypen die al ingebed zijn. Als een beschikbare stijl `NO_SUBSETTING` heeft, wordt voor dat lettertype‑familie alle tekens ingesloten.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Deze inspectie rapporteert de beperkingen die in elk lettertype‑bestand zijn gecodeerd. Het verleent geen licentie, bewijst niet dat je het lettertype legaal hebt verkregen, en vervangt niet de controle van de licentie‑overeenkomst van het lettertype vóór distributie van een ingebedde kopie.

## **Embedded fonts toevoegen**

Gebruik [add_embedded_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/add_embedded_font/) om een lettertype in te sluiten. De overloads accepteren ofwel een [FontData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontdata/)‑object of een byte‑array met de lettertype‑gegevens. De [EmbedFontCharacters](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/embedfontcharacters/)‑enumeratie bepaalt welke tekens worden meegenomen:

- [ALL](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/embedfontcharacters/) sluit alle tekens van het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- [ONLY_USED](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/embedfontcharacters/) sluit alleen de tekens in die in de presentatie worden gebruikt om de bestandsgrootte te verkleinen. Kies deze optie voor een definitieve presentatie die voornamelijk bedoeld is om bekeken te worden.

Het volgende voorbeeld gebruikt [get_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_fonts/) om de lettertypen op te halen die in `Fonts.pptx` worden gebruikt en embedt die die nog niet zijn ingesloten. De toe te voegen lettertypen moeten beschikbaar zijn op de machine die de code uitvoert. Bestaande embedded fonts behouden hun huidige tekensets.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Embedded fonts comprimeren**

[compress_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) verkleint embedded font‑data door ongebruikte tekens te verwijderen. Het werkt op lettertypen die al zijn ingesloten, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertype‑gegevens de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Bewaar het originele bestand als ontvangers later tekst moeten kunnen toevoegen. Tekens die tijdens de compressie zijn verwijderd, zijn niet meer beschikbaar vanuit het embedded lettertype, zelfs als je oorspronkelijk alle tekens had ingesloten.

## **FAQ**

**Hoe kan ik controleren of een embedded font nog steeds wordt vervangen tijdens het renderen?**

Roep [get_substitutions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/) aan in de omgeving waarin je de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor [font substitution](/slides/nl/python-net/font-substitution/) en de [font fallback](/slides/nl/python-net/fallback-font/)‑regels. Fallback behandelt ontbrekende tekens, dus het insluiten van een lettertype lost geen tekens op die het lettertype zelf niet bevat.

**Moet ik veelgebruikte lettertypen zoals Arial en Calibri insluiten?**

Baseer de beslissing op de doelomgeving. Als de benodigde lettertypen op elke machine die de presentatie opent of rendert beschikbaar zijn, kan het insluiten ervan onnodige bestandsgrootte toevoegen. Als ontvangers of servers deze lettertypen mogelijk missen, kan insluiten helpen om het beoogde uiterlijk te behouden, mits hun licenties dit toestaan.