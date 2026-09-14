---
title: Bädda in typsnitt i presentationer i Python via Java
linktitle: Inbäddade typsnitt
type: docs
weight: 40
url: /sv/python-java/embedded-font/
keywords:
- lägga till typsnitt
- inbädda typsnitt
- typsnittsinbäddning
- hämta inbäddat typsnitt
- lägga till inbäddat typsnitt
- ta bort inbäddat typsnitt
- komprimera inbäddat typsnitt
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera inbäddade typsnitt i PowerPoint med Aspose.Slides för Python via Java. Lägg till, hämta, ta bort och komprimera typsnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Inbäddning av typsnitt lagrar typsnittdata i en PowerPoint-presentation. När en visare stöder inbäddade typsnitt kan den visa text med dessa typsnitt även om de inte är installerade på mål­systemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides för Python via Java låter dig hämta, lägga till och ta bort inbäddade typsnitt via klassen [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/) som returneras av [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getFontsManager). Du kan också minska storleken på inbäddade typsnittdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX‑filer. Innan du bäddar in ett typsnitt, se till att dess typsnittdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade typsnitt**

Använd [getEmbeddedFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) för att lista typsnitten som lagras i en presentation. För att ta bort ett, skicka ett typsnitt från den listan till [removeEmbeddedFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), och spara sedan presentationen.

Följande exempel listar de inbäddade typsnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat typsnitt tar bort dess lagrade typsnittdata; det ändrar inte det typsnitt som är tilldelat texten. Om typsnittet är installerat på mål­systemet kan texten fortfarande använda det. Annars kan rendering kräva typsnittssubstitution, vilket kan påverka layouten.

## **Inspektera typsnittsdata och inbäddningsbehörigheter**

Använd klassen [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/) för att inspektera typsnitt innan de bäddas in. Anropa [FontsManager.getFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getFonts) för att hämta de typsnitt som används i presentationen. För varje typsnitt, skicka ett [FontData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontdata/)-objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontstyletype/)-värdet till [FontsManager.getFontBytes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getFontBytes). Metoden returnerar de binära data för den typsnittsstilen, eller `None` när det begärda typsnittet eller stilen inte är tillgänglig. Skicka inte ett `None`‑resultat till [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar de inbäddningsrestriktioner som lagras i typsnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, under förutsättning att typsnittslicensen tillåter det.
- `Restricted` förbjuder inbäddning om inte tillstånd erhålls från typsnittets juridiska ägare när det är det enda användnings‑tillståndsflaggan.
- `PreviewPrint` tillåter temporär användning för visning och utskrift; ett dokument som innehåller typsnittet måste vara skrivskyddat.
- `Editable` tillåter temporär användning och gör att dokumentet kan redigeras och sparas.
- `NoSubsetting` är en ytterligare restriktion som förbjuder inbäddning av endast en delmängd av glyferna. Bädda in alla tecken när detta flagga är närvarande.
- `BitmapOnly` är en ytterligare restriktion som endast tillåter inbäddning av bitmap‑strikes, inte konturdata. Om typsnittet inte har bitmap‑strikes kan det inte bäddas in.

De första fyra värdena beskriver användningstillstånd, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, maskera användningstillstånds‑bitarna och jämför resultatet med `Installable` i stället för att kontrollera det som ett flagga. Aktuella typsnitt bör sätta högst en användningstillstånds‑bit. För kompatibilitet med äldre typsnitt som sätter fler än en, väljer hjälpfunktionen nedan den minst restriktiva tillståndet: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, feta, kursiva och fet‑kursiva data som finns för varje typsnitt som returneras av `getFonts`. Det hoppar över otillgängliga stilar, restrikterade typsnitt, enbart‑bitmap‑typsnitt, typsnitt som är begränsade till förhandsgranskning och utskrift eftersom utdata förblir redigerbar, samt typsnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddas alla tecken in för den typsnittsfamiljen.

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

Denna inspektion rapporterar de restriktioner som kodas i varje typsnittfil. Den ger ingen licens, bevisar inte att du har skaffat typsnittet lagligt, eller ersätter kontrollen av typsnittets licensavtal innan en inbäddad kopia distribueras.

## **Lägg till inbäddade typsnitt**

Använd [addEmbeddedFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) för att bädda in ett typsnitt. Dess överlagringar accepterar antingen ett [FontData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontdata/)-objekt eller en byte‑array som innehåller typsnittsdatan. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/python-java/aspose.slides/embedfontcharacters/) styr vilka tecken som inkluderas:

- [All](https://reference.aspose.com/slides/sv/python-java/aspose.slides/embedfontcharacters/) bäddar in alla tecken i typsnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och skriva in ny text.
- [OnlyUsed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/embedfontcharacters/) bäddar in endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som huvudsakligen är avsedd för visning.

Följande exempel använder [getFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getFonts) för att hämta de typsnitt som används i `Fonts.pptx` och bäddar in de som ännu inte är inbäddade. Typsnitten som ska läggas till måste vara tillgängliga på maskinen som kör koden. Befintliga inbäddade typsnitt behåller sina nuvarande teckenuppsättningar.

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

## **Komprimera inbäddade typsnitt**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compress/#compressEmbeddedFonts) minskar inbäddade typsnittsdatan genom att ta bort oanvända tecken. Det verkar på typsnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvänd typsnittsd data presentationen innehåller.

Följande exempel komprimerar typsnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

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

Behåll originalfilen om mottagarna kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade typsnittet, även om du ursprungligen bäddade in alla tecken.

## **Vanliga frågor**

**Hur kan jag kontrollera om ett inbäddat typsnitt fortfarande kommer att ersättas under rendering?**

Anropa [getSubstitutions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#getSubstitutions) i den miljö där du renderar presentationen för att se vilka typsnitt Aspose.Slides kommer att ersätta. Kontrollera också inställningarna för typsnittssubstitution och reglerna för typsnittsfallback. Fallback hanterar saknade tecken, så inbäddning av ett typsnitt löser inte tecken som själva typsnittet inte innehåller.

**Borde jag bädda in vanliga typsnitt som Arial och Calibri?**

Basera beslutet på målmiljön. Om de nödvändiga typsnitten finns tillgängliga på varje maskin som öppnar eller renderar presentationen kan inbäddning av dem lägga till onödig filstorlek. Om mottagare eller servrar kan sakna dessa typsnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.