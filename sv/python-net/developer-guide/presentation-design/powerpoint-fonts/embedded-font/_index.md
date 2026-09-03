---
title: Bädda in teckensnitt i presentationer med Python
linktitle: Inbäddade teckensnitt
type: docs
weight: 40
url: /sv/python-net/embedded-font/
keywords:
- lägga till teckensnitt
- bädda in teckensnitt
- inbäddning av teckensnitt
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera inbäddade teckensnitt i PowerPoint med Aspose.Slides för Python via .NET. Använd Python för att lägga till, hämta, ta bort och komprimera teckensnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Inbäddade teckensnitt lagrar teckensnittsdata i en PowerPoint‑presentation. När en visare stödjer inbäddade teckensnitt kan den visa text med dessa teckensnitt även om de inte är installerade på mål­systemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides for Python via .NET låter dig hämta, lägga till och ta bort inbäddade teckensnitt via egenskapen [fonts_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/fonts_manager/) för ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt. Du kan också minska storleken på inbäddad teckensnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX‑filer. Innan du bäddar in ett teckensnitt, säkerställ att dess teckensnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade teckensnitt**

Använd [get_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) för att lista teckensnitten som lagras i en presentation. För att ta bort ett, skicka ett teckensnitt från den listan till [remove_embedded_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/remove_embedded_font/), och spara sedan presentationen.

Följande exempel listar de inbäddade teckensnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat teckensnitt tar bort dess lagrade teckensnittsdata; det ändrar inte det teckensnitt som är tilldelat texten. Om teckensnittet är installerat på mål­systemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/python-net/font-substitution/), vilket kan påverka layouten.

## **Inspektera teckensnittsdata och inbäddningsbehörigheter**

Använd klassen [FontsManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/) för att inspektera teckensnitt innan de bäddas in. Anropa [get_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_fonts/) för att hämta teckensnitten som används i presentationen. För varje teckensnitt, skicka ett [FontData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontdata/)-objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontstyletype/)-värdet till [get_font_bytes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_font_bytes/). Metoden returnerar de binära data för den teckensnittsstilen, eller `None` när det begärda teckensnittet eller stilen inte är tillgänglig. Skicka inte ett `None`‑resultat till [get_font_embedding_level](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/python-net/aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar inbäddningsrestriktionerna som lagras i teckensnittet:

- `INSTALLABLE` tillåter inbäddning och permanent installation på ett annat system, under förutsättning att teckensnittets licens tillåter det.
- `RESTRICTED` förbjuder inbäddning om inte tillstånd erhålls från teckensnittets juridiska ägare när det är det enda användarbehörighetsflaggan.
- `PREVIEW_PRINT` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller teckensnittet måste vara skrivskyddat.
- `EDITABLE` tillåter tillfällig användning och tillåter att dokumentet redigeras och sparas.
- `NO_SUBSETTING` är en ytterligare begränsning som förbjuder att bara en delmängd av tecknen bäddas in. Bädda in alla tecken när detta flagga är närvarande.
- `BITMAP_ONLY` är en ytterligare begränsning som endast tillåter att bitmap‑versioner av teckensnittet bäddas in, inte vektor‑data. Om teckensnittet saknar bitmap‑versioner kan det inte bäddas in.

De fyra första värdena beskriver användarbehörighet, medan `NO_SUBSETTING` och `BITMAP_ONLY` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `INSTALLABLE` är noll, maskera användarbehörighets‑bitarna och jämför resultatet med `INSTALLABLE`. Aktuella teckensnitt bör sätta högst en användarbehörighets‑bit. För kompatibilitet med äldre teckensnitt som sätter fler än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `EDITABLE`, sedan `PREVIEW_PRINT`, sedan `RESTRICTED`.

Följande exempel granskar de vanliga, fetstil‑, kursiv‑ och fet‑kursiv‑data som finns för varje teckensnitt som returneras av `get_fonts`. Det hoppar över otillgängliga stilar, restrikterade teckensnitt, enbart‑bitmap‑teckensnitt, teckensnitt begränsade till förhandsgranskning och utskrift eftersom utdata förblir redigerbar, samt teckensnitt som redan är inbäddade. Om någon tillgänglig stil har `NO_SUBSETTING` bäddar det in alla tecken för den teckensnittsfamiljen.

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

Denna inspektion rapporterar restriktionerna som kodas i varje teckensnitt fil. Den beviljar ingen licens, bevisar inte att du har skaffat teckensnittet lagligt, eller ersätter kontrollen av teckensnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade teckensnitt**

Använd [add_embedded_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/add_embedded_font/) för att bädda in ett teckensnitt. Dess överlagringar accepterar antingen ett [FontData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontdata/)-objekt eller en byte‑array som innehåller teckensnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/embedfontcharacters/) styr vilka tecken som inkluderas:

- [ALL](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/embedfontcharacters/) bäddar in alla tecken i teckensnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och lägga till ny text.
- [ONLY_USED](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/embedfontcharacters/) bäddar in endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som huvudsakligen är avsedd för visning.

Följande exempel använder [get_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_fonts/) för att hämta teckensnitten som används i `Fonts.pptx` och bäddar in dem som ännu inte är inbäddade. Teckensnitten som ska läggas till måste finnas på maskinen som kör koden. Befintliga inbäddade teckensnitt behåller sina nuvarande teckenuppsättningar.

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

## **Komprimera inbäddade teckensnitt**

[compress_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) minskar inbäddad teckensnittsdata genom att ta bort oanvända tecken. Den arbetar på teckensnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvänd teckensnittsdata presentationen innehåller.

Följande exempel komprimerar teckensnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Behåll originalfilen om mottagarna kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade teckensnittet, även om du ursprungligen bäddade in alla tecken.

## **FAQ**

**Hur kan jag kontrollera om ett inbäddat teckensnitt fortfarande kommer att ersättas vid rendering?**

Anropa [get_substitutions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_substitutions/) i den miljö där du renderar presentationen för att se vilka teckensnitt Aspose.Slides kommer att ersätta. Kontrollera också inställningarna för [font substitution](/slides/sv/python-net/font-substitution/) och [font fallback](/slides/sv/python-net/fallback-font/). Fallback hanterar saknade tecken, så inbäddning av ett teckensnitt löser inte tecken som teckensnittet självt inte innehåller.

**Bör jag bädda in vanliga teckensnitt som Arial och Calibri?**

Basera beslutet på mål­miljön. Om de nödvändiga teckensnitten finns på varje maskin som öppnar eller renderar presentationen kan inbäddning öka filstorleken onödigt. Om mottagare eller servrar kan sakna dessa teckensnitt kan inbäddning hjälpa till att bevara avsedd utseende, förutsatt att deras licenser tillåter det.