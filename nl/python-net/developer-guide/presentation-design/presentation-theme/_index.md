---
title: "Beheer PowerPoint-presentatiethema's in Python"
linktitle: "Presentatiethema"
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
- themakleur
- aanvullend palet
- themalettertype
- themastijl
- thema‑effect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor Python via .NET om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Themagevoelige objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) eigenschap. Een presentatie kan ook themabijstellingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/masterthememanager/override_theme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia opgelost via deze erfketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Thema‑onderdelen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De secties hieronder tonen de meest voorkomende themaworkflows: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat erf‑ en overschrijvingsregels zijn toegepast.

## **Inspecteer een thema**

Het [MasterTheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/) object maakt de thema‑eigenschappen [color_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/font_scheme/), en [format_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/format_scheme/) beschikbaar. Het inspecteren van deze collecties voordat u ze wijzigt is bijzonder nuttig wanneer een presentatie afkomstig is uit een externe bron, omdat het aantal en de inhoud van stijl‑items kunnen variëren.

Het volgende voorbeeld leest de hoofdthema‑eigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Themagevoelige vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/). Wanneer u het bijbehorende item in het thema‑[ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/) wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet gewijzigd door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `ACCENT4` gebruikt, verandert de thema‑`accent4` kleur naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve vulkleur af:

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

Omdat het rechthoekige object gekoppeld blijft aan `ACCENT4`, wordt de zichtbare kleur rood nadat het thema is aangepast. Als u de schema‑kleur vervangt door een directe kleur op de vorm, zullen latere wijzigingen van `accent4` die vulkleur niet meer beïnvloeden.

### **Kleuren uit het aanvullende palet gebruiken**

PowerPoint genereert lichtere en donkere varianten van een themakleur door kleurtransformaties toe te passen. Aspose.Slides stelt deze transformaties beschikbaar via de enumeratie [ColorTransformOperation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkere kleuren gegenereerd uit het aanvullende palet](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.  

**2** – Lichtere en donkere varianten die zijn voortgebracht uit de hoofdkleuren.

Het volgende voorbeeld maakt zes rechthoeken gebaseerd op `ACCENT4`, past luminantietransformaties toe op vijf ervan, en slaat het resultaat op:

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

Deze varianten blijven gebaseerd op de themakleur. Als `accent4` later verandert, worden de getransformeerde kleuren opnieuw berekend op basis van de nieuwe `accent4`‑waarde.

### **Map `SchemeColor`‑waarden naar `ColorScheme`‑posities**

De enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) gebruikt `TEXT1`, `BACKGROUND1`, `TEXT2` en `BACKGROUND2`, terwijl [ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/) dezelfde themaposities blootlegt als `dark1`, `light1`, `dark2` en `light2`. De mapping is vast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dit zijn alternatieve namen voor dezelfde themaposities; ze zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Themallettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire set voor body‑tekst. De eigenschappen [FontScheme.major](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/major/) en [FontScheme.minor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/minor/) maken die sets beschikbaar.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen in tekstopmaak worden gebruikt:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het hoofd‑Latin‑themale lettertype gebruikt en één body‑regel die het secundaire Latin‑themale lettertype gebruikt. Vervolgens wijzigt het de thema‑lettertypen en slaat het resultaat op:

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

De kop volgt het hoofd‑lettertype en de body‑tekst volgt het secundaire lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch overschakelen wanneer het thema‑lettertype‑schema wordt aangepast.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑mappingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze mappingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatie‑lettertypen, zie [PowerPoint Fonts](/slides/nl/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

Er zijn twee gangbare workflows, en ze lossen verschillende problemen op.

### **Bron‑thema behouden bij verplaatsen van dia's**

Wilt u een dia naar een andere presentatie verplaatsen en tegelijk het oorspronkelijke ontwerp behouden, kloont u de bron‑master in de doelpresentatie met [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/add_clone/), en kloont u vervolgens de dia met [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) en de gekloonde master. Hierdoor worden de master, zijn lay‑outs en het bijbehorende thema gezamenlijk overgebracht.

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

Dit is de geprefereerde workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud op een ongekende bestemming‑master kan themagestuurde kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Themawaarden toepassen op een bestaande dia**

Moet de doel‑dia op de huidige master en lay‑out blijven, initialiseert u een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) en [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiëren de drie hoofdthema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat door die dia wordt gebruikt zonder het thema dat door andere dia's wordt geërfd te veranderen. Om de lokale overschrijving te verwijderen en terug te gaan naar erfd waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een themabijstelling toepassen op een lay‑out**

Een lay‑out‑niveau overschrijving is van toepassing op alle dia's die die lay‑out gebruiken, tenzij een specifieke dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de lay‑out‑[LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Gebruik een master‑ of presentatieniveau‑thema wanneer veel lay‑outs en dia's hetzelfde basisontwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑outfamilie een andere styling vereist, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale themawijzigingen moeilijker te voorspellen.

## **Achtergrondstijlen van het thema bijwerken**

De achtergrondvullingen van het thema worden bewaard in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan meer achtergrondkeuzes in de UI presenteren dan het aantal vuldefinities dat fysiek in deze collectie is opgeslagen, omdat de UI themavullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteert u de opgeslagen collectie en de huidige [Background.style_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/style_index/). `style_index` gebruikt `0` voor geen themavulling; positieve waarden zijn verwijzingen naar themachtergrond‑stijlen. Dit verschilt van het indexeren van een Python‑collectie, waarbij `[0]` het eerste opgeslagen item betekent. Ga er dus niet van uit dat elke presentatie hetzelfde aantal achtergrondvullingsstijlen bevat.

Het volgende voorbeeld meldt het aantal beschikbare achtergrondvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themareferentie die door de master wordt gebruikt en van eventuele achtergrond‑overschrijvingen op lay‑out‑ of dia‑niveau. Als een dia een eigen achtergrond heeft, kan het wijzigen van alleen de master‑achtergrond die dia niet beïnvloeden. Gebruik [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/) wanneer u de uiteindelijke achtergrond na erf‑ en overschrijvingsregels wilt weten.

{{% alert color="warning" title="Waarschuwing" %}}
Behandel `style_index` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en aannemen dat het dezelfde weergave heeft in een ander bestand; themastijldefinities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑erfenis, zie [Presentation Background](/slides/nl/python-net/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑format‑schema bevat afzonderlijke collecties [FormatScheme.fill_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/line_styles/), en [FormatScheme.effect_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑thema’s bevatten vaak drie belangrijke stijl‑items die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vast aantal aan te nemen.

![Subtiele, gematigde en intensieve thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Python benadert, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die themastijl refereren; vormen met directe opmaak blijven mogelijk ongewijzigd.

Het volgende voorbeeld controleert of de vereiste stijl‑items aanwezig zijn, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die naar deze posities verwijzen, wordt de eerste themalijnstijl rood, de derde themavulstijl een stevige bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijlposities elke vorm referereert en of directe opmaak de thema‑instellingen overschrijft.

![Thema‑effectstijlen na wijziging van lijn‑, vul‑ en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe thema‑objecten laten zien wat op een bepaald niveau is gedefinieerd. Effectieve waarden laten zien wat een dia of vorm daadwerkelijk gebruikt nadat erf‑ en lokale overschrijvingsregels zijn toegepast. Voor een dia roept u [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) aan. Voor een achtergrond gebruikt u [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/), en voor een vul vulling [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond, en de eerste vormvulling van een dia:

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

Gebruik effectieve data voor weergave‑diagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die de uiteindelijke weergave verandert.

## **FAQ**

**Kan ik een thema toepassen op één enkele dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert zijn overschrijvings‑thema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te brengen?**

Wanneer u een dia verplaatst en het oorspronkelijke uiterlijk wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/add_clone/) en [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/). Zo blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien nadat erf‑ en overschrijvingsregels zijn toegepast?**

Gebruik [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑data‑methoden voor format‑objecten zoals [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/) en [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/). Deze API‑s retourneren de opgeloste waarden nadat erf‑ en overschrijvingsregels zijn toegepast.