---
title: Beheer PowerPoint-presentatiethema's in Python
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/python-net/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- extern thema
- THMX
- themakleur
- aanvullend palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor Python via .NET om PowerPoint-bestanden te maken, aanpassen en converteren met een consequente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de eigenschap [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). Een presentatie kan ook thema‑overschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia opgelost via deze erfenisketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erfenis en overschrijvingen zijn opgelost.

## **Een thema inspecteren**

Het object [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) biedt toegang tot de eigenschappen [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) en [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) van het thema. Deze collecties inspecteren voordat u ze wijzigt is vooral nuttig wanneer een presentatie afkomstig is van een externe bron, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste thema‑eigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen in het thema zijn opgeslagen:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme

    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Als een bestand meerdere masters gebruikt, ga er niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de enumeratie [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). Wanneer u de bijbehorende invoer in de [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) van het thema wijzigt, worden alle objecten die nog naar die themakleur verwijzen, aangepast aan de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `ACCENT4` gebruikt, wijzigt de themakleur `accent4` naar rood, slaat de presentatie op, opent deze opnieuw en drukt de effectieve vulkleur af:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    presentation.master_theme.color_scheme.accent4.color = draw.Color.red

    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Omdat het rechthoekige object verbonden blijft met `ACCENT4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als u de schemakleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkere varianten van een themakleur door kleurovergangen toe te passen. Aspose.Slides biedt deze transformaties via de enumeratie [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkere varianten geproduceerd uit de hoofdkleuren van het thema.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `ACCENT4`, past luminantie‑transformaties toe op vijf ervan, en slaat het resultaat op:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Deze varianten blijven gebaseerd op de themakleur. Als `accent4` later wijzigt, worden de getransformeerde kleuren opnieuw berekend vanuit de nieuwe `accent4`‑waarde.

### **`SchemeColor`‑waarden naar `ColorScheme`‑posities mappen**

De enumeratie [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) gebruikt `TEXT1`, `BACKGROUND1`, `TEXT2` en `BACKGROUND2`, terwijl [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) dezelfde themaposities exposeert als `dark1`, `light1`, `dark2` en `light2`. De mapping is vast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dit zijn alternatieve namen voor dezelfde themaposities; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden geconverteerd.

## **Themalettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een onderlettertype‑set voor de hoofdtekst. De eigenschappen [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) en [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) exposen die sets.

Thema‑compatible lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn‑lt` – Body Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading Font Latin (Major Latin Font)
* `+mn‑ea` – Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading Font East Asian (Major East Asian Font)
* `+mn‑cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Heading Font Complex Script (Major Complex Script Font)

Het volgende voorbeeld maakt een kop die het hoofd‑Latin‑themalettertype gebruikt en een alinea die het onder‑Latin‑themalettertype gebruikt. Vervolgens wijzigt het de themalettertypen en slaat het resultaat op:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")

    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")

    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")

    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

De kop volgt het hoofdlettertype en de hoofdtekst volgt het onderlettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De hoofd‑ en onder‑lettertype‑collecties kunnen ook lettertype‑mappingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Voor inspectie, toevoegen, vervangen of verwijderen van deze mappingen, zie [Script‑Specific Theme Fonts](/slides/nl/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Voor meer informatie over presentatietekstlettertypen, zie [PowerPoint Fonts](/slides/nl/python-net/powerpoint-fonts/).

{{% /alert %}}

### **Thema‑lettertypereferenties oplossen**

Bij het inspecteren van tekst kan [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) een themareferentie bevatten zoals `+mn‑lt` in plaats van een lettertype‑familienaam. Roep [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) aan met de juiste [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) om die referentie op te lossen. De prefixes `+mj` en `+mn` selecteren respectievelijk de hoofd‑ en onder‑lettertype‑sets; de suffixen `-lt`, `-ea` en `-cs` selecteren hun Latin, East Asian en Complex Script‑lettertypen.

Verkrijg het effectieve thema via [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) op het object waarvan het thema op de geïnspecteerde tekst van toepassing is. Voor gewone tekst op een dia, gebruik `slide.create_theme_effective` zodat de context de geërfde themastijl van die dia en lokale overschrijvingen omvat. Bij inspectie van een lay‑out of master, gebruik dan het eigen effectieve thema. Ga er niet van uit dat het thema van de eerste master voor elke dia geldt.

Het volgende voorbeeld maakt een tekstgedeelte dat expliciet naar het onder‑Latin‑lettertype verwijst. Het initialiseert een dia‑lettertype‑schema via [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) en stelt de hoofd‑ en onder‑Latin‑families in op `Arial` en `Calibri`, waardoor het resultaat reproduceerbaar is zonder invoerbestand.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

De uitvoer is `+mn‑lt -> Calibri` gevolgd door `Verdana -> Verdana`. De opgeslagen referentie blijft ongewijzigd, terwijl een expliciete familienaam ongewijzigd wordt geretourneerd. Als het gedeelte `+mj‑lt` zou gebruiken, zou het naar `Arial` oplossen in dit thema.

Het oplossen van een thema‑referentie identificeert het door het thema opgegeven lettertype‑familie. Het controleert niet de beschikbaarheid van het lettertype of bepaalt welk lettertype‑bestand uiteindelijk wordt gebruikt na substitutie of fallback tijdens het renderen. Zie [Font Selection Sequence](/slides/nl/python-net/font-selection-sequence/) en [Font Substitution](/slides/nl/python-net/font-substitution/) voor die afzonderlijke stappen.

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia’s die van een master afhankelijk zijn**

Gebruik [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) wanneer u een PowerPoint‑thema‑bestand (`.thmx`) hebt en iedere dia die van een bepaalde master afhankelijk is, opnieuw wilt vormgeven. Selecteer de master uit de collectie [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) en geef het themabestandspad door aan de methode.

De methode voert de volgende stappen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Wijst de nieuwe master toe aan alle dia’s die voorheen van de geselecteerde master afhankelijk waren.
1. Retourneert de nieuw aangemaakte [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

Het volgende voorbeeld past een extern thema toe op de dia’s die van de eerste master afhankelijk zijn en slaat de presentatie op:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) of een van de opmaakgerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, handel fouten bij bestands‑systeem‑toegang af, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia’s die van de geselecteerde master afhankelijk waren, worden opnieuw toegewezen. Dia’s die aan andere masters zijn gekoppeld behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden geëvalueerd ten opzichte van het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen onveranderd blijven. Overschrijvingen op lay‑out‑ of dia‑niveau kunnen eveneens voorrang krijgen boven waarden die zijn geërfd van de nieuwe master.

Het thema kan verwijzen naar lettertypen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/python-net/custom-font/), of configureer [font substitution](/slides/nl/python-net/font-substitution/).

Dit is een directe master‑niveau werkstroom: de methode accepteert een bestandspad naar een `.thmx`‑bestand en vereist geen handmatige creatie van dia‑ of lay‑out‑thema‑overschrijvingen.

### **Verschillende externe thema’s toepassen in een multi‑master presentatie**

Wanneer de relevante master van tevoren niet bekend is, haal deze op via een representatieve dia met [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) en [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Bewaar de oorspronkelijke master‑referenties voordat u thema’s toepast, want elke oproep creëert een nieuwe master in de presentatie.

Het volgende voorbeeld gebruikt dia’s uit twee secties om hun masters te lokaliseren en past een ander extern thema toe op elke groep:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

De eerste oproep heeft alleen invloed op dia’s die afhankelijk waren van `first_group_master`, en de tweede oproep alleen op dia’s die afhankelijk waren van `second_group_master`. Dia’s die tot een andere master behoren, worden niet opnieuw vormgegeven.

### **Een bron‑thema behouden bij het verplaatsen van dia’s**

Wilt u een dia naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master naar de doelpresentatie met [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), en kloon vervolgens de dia met [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) en de gekloonde master. Hierdoor worden de master, zijn lay‑outs en het bijbehorende thema samen meegenomen.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]

        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Dit is de aanbevolen werkstroom wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Alleen de inhoud klonen naar een ongeassocieerde doel‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑waarden toepassen op een bestaande dia**

Moet de doel‑dia op zijn huidige master en lay‑out blijven, initialiseert u een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) en [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]

        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Dit verandert het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia’s wordt geërfd te wijzigen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑niveau overschrijving geldt voor dia’s die die lay‑out gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) van de lay‑out:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Gebruik een master‑ of presentatiethema wanneer veel lay‑outs en dia’s hetzelfde basisontwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑outfamilie een andere stijl nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale thema‑wijzigingen moeilijker voorspelbaar.

## **Thema‑achtergrondstijlen bijwerken**

De achtergrondvullingen van het thema worden opgeslagen in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan meer achtergrondkeuzes presenteren in de UI dan het aantal fysiek opgeslagen vuldefinities in deze collectie, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` gebruikt `0` voor geen themavulling; positieve waarden zijn referenties naar themabackground‑stijlen. Dit verschilt van het indexeren van een Python‑collectie, waar `[0]` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrondvullingen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:

    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")

    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")

    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1

    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Het zichtbare resultaat hangt af van de themainvoer waarnaar de master verwijst en van eventuele achtergrondoverschrijvingen op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia onveranderd laten. Gebruik [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) wanneer u de definitieve achtergrond na erfenis moet weten.

{{% alert color="warning" title="Warning" %}}

Behandel `style_index` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/python-net/presentation-background/).

{{% /alert %}}

## **Thema‑effecten bijwerken**

Een themaschema bevat afzonderlijke collecties [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) en [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑thema’s bevatten vaak drie hoofd‑stijlen die visueel overeenkomen met subtiele, matige en intense opmaak, maar code moet elke collectie inspecteren in plaats van uit te gaan van een vast aantal.

![Subtiele, matige en intense themaeffecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Python benadert, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgelegd via [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")

    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Voor vormen die deze posities refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl een effen bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijl‑posities elke vorm referereert en of directe opmaak de thema‑instelling overschrijft.

![Thema‑effectstijlen na wijziging van lijn, vul en schaduwinstellingen](presentation-design_11.png)

## **Vul‑ en lijnstijlen voor een vorm selecteren**

Een vorm kan onafhankelijk zijn vul‑ en omtrekstijl kiezen via [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) en [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). Voor beide eigenschappen selecteert index `1` het eerste item in de betreffende themacollectie (`fill_styles[0]` of `line_styles[0]`), en selecteert index `2` het tweede item.

Het volgende voorbeeld definieert twee vullingen (goud en hemelsblauw) en twee omtrekken (donkerblauw op 6 pt en donkerrood op 12 pt) in het standaardthema van een nieuwe presentatie. Het slaat de dia op drie momenten op zodat u de resultaten in PowerPoint kunt vergelijken.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Beginstijlen | Rechte omtrek wijzigen | Eerste themavulling bewerken |
|:---:|:---:|:---:|
| ![Gouden en hemelsblauwe rechthoeken met dunne donkere blauwe omtrek](theme-style-initial.png) | ![De hemelsblauwe rechthoek heeft nu een dikke donkerrode omtrek](theme-style-line-changed.png) | ![De linkse rechthoek is nu groen en beide omtrekken blijven ongewijzigd](theme-style-fill-changed.png) |

Het selecteren van een andere lijnstijl wijzigt alleen de omtrek van de rechterrechthoek. Het bewerken van de eerste themavulling werkt elke vorm bij die deze gebruikt. Hier wordt alleen de linkse rechthoek groen.

Op een bestaande vorm kan een lokale vulkleur, lijnkleur of lijndikte die thema‑stijl overschrijven. Als het wijzigen van een stijlindex geen zichtbaar effect heeft, controleer dan de [directe opmaak](/slides/nl/python-net/shape-formatting/) van de vorm.

## **Bepalen of een effectieve effen vul een themakleur gebruikt**

Een vul kan direct op een object worden opgeslagen of geërfd van een alinea, lay‑out, master, themastijl of een ander formatteringsniveau. Roep [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) aan om die hiërarchie om te zetten in een onveranderlijk [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Alleen wanneer deze `FillType.SOLID` is, dient u de eigenschappen van de effen vul te lezen.

Voor een effen vul geeft [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) de definitieve weergegeven RGB‑waarde terug na erfenis, themalook‑up en kleurovergangen. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) geeft de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/)‑slot terug, zoals `TEXT1` of `ACCENT6`. Een waarde van `SchemeColor.NOT_DEFINED` betekent dat de effectieve effen vul niet gebaseerd is op een schemakleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vul.

Gebruik niet alleen de lokale waarde [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) om een vul te classificeren. Een tekstgedeelte kan bijvoorbeeld geen lokaal gedefinieerde schemakleur hebben, waardoor zijn lokale waarde `NOT_DEFINED` is, terwijl de effectieve vul een themakleur erft en oplost naar `TEXT1` of `ACCENT6`. Omgekeerd vertelt `solid_fill_scheme_color` u welke logische themaslot de effectieve kleur heeft geproduceerd, maar niet van welk niveau (object, alinea, lay‑out, master, …) die slot afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekst‑gedeelte‑vullingen, drukt elke uiteindelijke RGB‑waarde en bijbehorende schemakleur af, en markeert effen vullingen die geen themakleur‑wijzigingen volgen:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

De `NOT_DEFINED`‑tak levert een audit‑lijst van effen vullingen die niet reageren op wijzigingen in themakleur‑slots. Bekijk die objecten wanneer een presentatie een nieuw merkkleurpalet moet volgen. De gerapporteerde RGB‑waarde toont nog steeds het huidige uiterlijk, terwijl de schema‑waarde uitlegt of dat uiterlijk aan het thema is gekoppeld.

Effectieve‑format‑objecten zijn momentopnamen. Na het wijzigen van het presentatiethema, een thema‑overschrijving of enige geërfde opmaak, roep opnieuw `get_effective` aan en lees een nieuw `IFillFormatEffectiveData`‑object voordat u kleuren vergelijkt of rapporteert.

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten tonen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden tonen wat een dia of vorm daadwerkelijk gebruikt na erfenis en lokale overschrijvingen. Voor een dia, roep [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) aan. Voor een achtergrond, gebruik [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), en voor een vul, gebruik [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormvul van een dia:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()

    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")

    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Gebruik effectieve data voor render‑diagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) inspecteert, kunt u een master, lay‑out, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) wijzigt alleen de dia’s die afhankelijk zijn van de geselecteerde master. Dia’s die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert de overschrijvings‑thema. De wijziging blijft lokaal voor die dia; andere dia’s blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en de oorspronkelijke weergave wilt behouden, kloon dan de bron‑master naar de bestemming en kloon de dia met die master via [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) en [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na erfenis en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) voor een dia‑ of lay‑out‑thema en de overeenkomstige effectieve‑data‑methoden voor format‑objecten zoals [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) en [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Deze API’s retourneren de opgeloste waarden na toepassing van erfenis en overschrijvingen.