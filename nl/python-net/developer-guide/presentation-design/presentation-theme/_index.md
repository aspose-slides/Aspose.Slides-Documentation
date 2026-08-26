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
description: "Beheers presentatie‑thema's in Aspose.Slides voor Python via .NET om PowerPoint‑bestanden te maken, aanpassen en converteren met consistente branding."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, opvullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een thema‑wijziging veel objecten in één keer kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de eigenschap [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/). Een presentatie kan ook thema‑overschrijvingen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/masterthememanager/override_theme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), en een individuele dia kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een dia bepaald via deze overervingsketen: presentatiethema, master‑overschrijving, lay‑out‑overschrijving en dia‑overschrijving.

![Themakelementen: kleuren, lettertypen, achtergrondstijlen en effecten](theme-constituents.png)

De onderstaande secties tonen de meest voorkomende thema‑werkstromen: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overschrijvingen zijn toegepast.

## **Inspecteer een thema**

Het object [MasterTheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/) geeft de eigenschappen [color_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/font_scheme/), en [format_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/format_scheme/) van het thema weer. Het inspecteren van deze collecties vóór wijziging is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en rapporteert hoeveel achtergrond‑, opvul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke dia hetzelfde effectieve thema heeft. Inspecteer de master die bij de dia hoort, en gebruik de effectieve‑thema‑werkstroom die later in dit artikel wordt getoond wanneer lay‑out‑ of dia‑overschrijvingen aanwezig kunnen zijn.

## **Themakleuren wijzigen**

Thema‑bewuste opvullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) enumeratie. Wanneer u de overeenkomstige entry in de [ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/) van het thema wijzigt, worden alle objecten die nog naar die themakleur verwijzen, bijgewerkt naar de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een themakleur‑update.

Het volgende end‑to‑end voorbeeld maakt een vorm die `ACCENT4` gebruikt, wijzigt de `accent4`‑kleur van het thema naar rood, slaat de presentatie op, opent deze opnieuw, en drukt de effectieve opvulkleur af:

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

Omdat het rechthoek nog steeds gekoppeld is aan `ACCENT4`, wordt zijn zichtbare kleur rood nadat het thema is gewijzigd. Als u de schemacolor vervangt door een directe kleur op de vorm, zullen latere wijzigingen aan `accent4` die opvulling niet meer beïnvloeden.

### **Gebruik kleuren uit het aanvullende palet**

PowerPoint haalt lichtere en donkerdere varianten uit een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties bloot via de enumeratie [ColorTransformOperation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/colortransformoperation/).

![Hoofdkleuren van het thema en lichtere en donkerdere kleuren gegenereerd vanuit het aanvullende palet](additional-palette-colors.png)

**1** - Hoofdkleuren van het thema.  
**2** - Lichtere en donkerdere varianten die zijn geproduceerd uit de hoofdkleuren van het thema.

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

Deze varianten blijven gebaseerd op de themakleur. Als `accent4` later verandert, worden de getransformeerde kleuren herberekend vanuit de nieuwe `accent4`‑waarde.

### **Map `SchemeColor`‑waarden naar `ColorScheme`‑posities**

De enumeratie [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) gebruikt `TEXT1`, `BACKGROUND1`, `TEXT2` en `BACKGROUND2`, terwijl [ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/) dezelfde themaposities blootlegt als `dark1`, `light1`, `dark2` en `light2`. De mapping is vast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dit zijn alternatieve namen voor dezelfde themaposities; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑lettertypen wijzigen**

Een thema‑lettertype‑schema bevat een hoofdlettertype‑set voor koppen en een secundaire lettertype‑set voor de hoofdtekst. De eigenschappen [FontScheme.major](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/major/) en [FontScheme.minor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/minor/) geven die sets weer.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt in tekstopmaak:

* `+mn-lt` - Bodylettertype Latin (Klein Latin lettertype)
* `+mj-lt` - Koplettertype Latin (Groot Latin lettertype)
* `+mn-ea` - Bodylettertype Oost-Aziatisch (Klein Oost-Aziatisch lettertype)
* `+mj-ea` - Koplettertype Oost-Aziatisch (Groot Oost-Aziatisch lettertype)

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

De kop volgt het hoofdlettertype en de hoofdtekst volgt het secundaire lettertype. Tekst die een expliciete lettertype‑naam heeft in plaats van een thema‑identifier, zal niet automatisch wisselen wanneer het thema‑lettertype‑schema wordt gewijzigd.

De hoofd‑ en secundaire lettertype‑collecties kunnen ook lettertype‑toewijzingen bevatten voor individuele schriftsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Zie [Script‑Specific Theme Fonts](/slides/nl/python-net/script-specific-font-mappings/) om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen.

{{% alert color="info" title="Tip" %}}
Voor meer informatie over presentatiellettertypen, zie [PowerPoint Fonts](/slides/nl/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Een thema kopiëren of toepassen**

De onderstaande werkstromen lossen verschillende thema‑gerelateerde problemen op.

### **Een extern thema toepassen op dia's die afhankelijk zijn van een master**

Gebruik [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) wanneer u een PowerPoint‑themabestand (`.thmx`) hebt en elke dia die afhankelijk is van een bepaalde master wilt herstylen. Selecteer de master uit de collectie [Presentation.masters](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/masters/), die [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/) implementeert, en geef het pad naar het themabestand door aan de methode.

De methode voert de volgende bewerkingen uit:

1. Maakt een nieuwe master‑dia op basis van de geselecteerde master.
2. Past het externe thema toe op de nieuwe master.
3. Wijs de nieuwe master toe aan alle dia's die eerder afhankelijk waren van de geselecteerde master.
4. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de dia's die afhankelijk zijn van de eerste master en slaat de presentatie op:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxexception/) of een van zijn op formaat gerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestandsysteem‑toegang, en sla de presentatie pas op nadat het thema succesvol is toegepast.

Alleen de dia's die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Dia's die aan andere masters zijn gekoppeld behouden hun bestaande masters en thema's. Thema‑bewuste kleuren, lettertypen, opvullingen, lijnen, achtergronden en effecten worden resolved tegen het externe thema. Direct toegewezen kleuren, lettertypen, opvullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overschrijvingen op lay‑out‑niveau en dia‑niveau kunnen ook voorrang krijgen boven waarden die van de nieuwe master zijn geërfd.

Het thema kan lettertypen verwijzen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/python-net/custom-font/), of configureer [font substitution](/slides/nl/python-net/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestands‑pad naar een `.thmx`‑bestand en vereist geen handmatige creatie van thema‑overschrijvingen op dia‑ of lay‑out‑niveau.

### **Verschillende externe thema's toepassen in een presentatie met meerdere masters**

Wanneer de relevante master niet van tevoren bekend is, verkrijg deze via een representatieve dia met [Slide.layout_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/layout_slide/) en [LayoutSlide.master_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/master_slide/). Sla de oorspronkelijke master‑referenties op voordat u thema's toepast, omdat elke aanroep een extra master in de presentatie creëert.

Het volgende voorbeeld gebruikt dia's uit twee secties om hun masters te lokaliseren en past een verschillend extern thema toe op elke groep:

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

De eerste oproep heeft alleen invloed op dia's die afhankelijk zijn van `first_group_master`, en de tweede oproep alleen op dia's die afhankelijk zijn van `second_group_master`. Dia's die tot een andere master behoren, worden niet opnieuw gestyled.

### **Behoud een bron‑thema bij het verplaatsen van dia's**

Als u een dia naar een andere presentatie wilt verplaatsen en het oorspronkelijke ontwerp wilt behouden, kloon dan de bron‑master naar de doelframeset met [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/add_clone/), kloon vervolgens de dia met [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) en de gekloonde master. Daarmee worden de master, zijn lay‑outs en het bijbehorende thema samen meegenomen.

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

Dit is de aanbevolen workflow wanneer de bron‑dia er in de bestemming precies hetzelfde uit moet zien. Het simpelweg klonen van inhoud naar een ongerelateerde doeldia‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Toepassen van themawaarden op een bestaande dia**

Als de doel‑dia op zijn huidige master en lay‑out moet blijven, initialiseert u een dia‑niveau overschrijving vanuit het bron‑thema. De methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), en [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiëren de drie hoofd‑thema‑componenten naar de overschrijving.

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

Dit wijzigt het thema dat die dia gebruikt zonder het thema dat door andere dia's wordt geërfd te veranderen. Om de lokale overschrijving te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een thema‑overschrijving toepassen op een lay‑out**

Een lay‑out‑niveau overschrijving wordt toegepast op dia's die die lay‑out gebruiken, tenzij een bepaalde dia een eigen overschrijving heeft. Dezelfde initialisatiemethoden kunnen via de [LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/layoutslidethememanager/) van de lay‑out worden gebruikt:

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

Gebruik een master‑ of presentatieniveau thema wanneer veel lay‑outs en dia's hetzelfde basisonwerp moeten delen, een lay‑out‑overschrijving wanneer één lay‑out‑familie een andere stijl nodig heeft, en een dia‑overschrijving alleen voor echte uitzonderingen. Overmatige dia‑niveau overschrijvingen maken latere globale thema‑wijzigingen moeilijker te voorspellen.

## **Thema‑achtergrondstijlen bijwerken**

De achtergrond‑opvullingen van het thema worden opgeslagen in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan meer achtergrondkeuzes in de UI weergeven dan het aantal opvulling‑definities dat fysiek in deze collectie is opgeslagen, omdat de UI themao​pvullingen kan combineren met themakleuren en andere stijlovereenkomsten.

![PowerPoint‑achtergrondstijlgallerij voor een presentatiethema](presentation-design_8.png)

Voordat u een achtergrondstijl gebruikt, inspecteer de opgeslagen collectie en de huidige [Background.style_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/style_index/). `style_index` gebruikt `0` voor geen thematische opvulling; positieve waarden zijn verwijzingen naar thematische achtergrondstijlen. Dit verschilt van het indexeren van een Python‑collectie direct, waarbij `[0]` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie hetzelfde aantal achtergrondopvullingsstijlen bevat.

Het volgende voorbeeld rapporteert het aantal beschikbare achtergrondopvullingen, kent een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de themainvoer die door de master wordt gerefereerd en van eventuele achtergrondoverschrijvingen op lay‑out‑ of dia‑niveau. Als een dia zijn eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die dia niet veranderen. Gebruik [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/) wanneer u de definitieve achtergrond wilt weten nadat overerving is toegepast.

{{% alert color="warning" title="Waarschuwing" %}}
Behandel `style_index` niet als een nulgebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn presentatiespecifiek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/python-net/presentation-background/).
{{% /alert %}}

## **Thema‑effecten bijwerken**

Een thema‑format‑schema bevat afzonderlijke collecties [FormatScheme.fill_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/line_styles/), en [FormatScheme.effect_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typische Office‑thema's bevatten vaak drie hoofd‑stijl‑items die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet elke collectie inspecteren in plaats van een vaste hoeveelheid aan te nemen.

![Subtiele, gematigde en intensieve thema‑effecten toegepast op dezelfde vorm](presentation-design_10.png)

Wanneer u deze collecties in Python benadert, is de collectie‑index nulgebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` de derde. De stijl‑referentie‑indexen van een vorm vormen een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die naar die themastijl verwijzen; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de vereiste stijlintenties bestaan, wijzigt de eerste lijnstijl, wijzigt de derde opvullingsstijl, schakelt een buitenste schaduw in bij de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die naar deze posities verwijzen, wordt de eerste themalijnstijl rood, de derde themapoppvullingsstijl wordt een effen bosgroen, en de derde effectstijl krijgt een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat hangt nog steeds af van welke stijlposities elke vorm verwijst en of directe opmaak het thema overschrijft.

![Thema‑effectstijlen na het wijzigen van lijn-, vul- en schaduwinstellingen](presentation-design_11.png)

## **Effectieve themawaarden lezen**

Ruwe themobjecten geven aan wat op een bepaald niveau is gedefinieerd. Effectieve waarden geven aan wat een dia of vorm daadwerkelijk gebruikt nadat overerving en lokale overschrijvingen zijn toegepast. Voor een dia, roep [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) aan. Voor een achtergrond, gebruik [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/), en voor een opvulling, gebruik [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vormopvulling van een dia:

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

Gebruik effectieve gegevens voor weergavediagnostiek, validatie en vergelijkingen. Als u alleen [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) inspecteert, kunt u een master‑, lay‑out‑, dia‑ of vorm‑overschrijving missen die het uiteindelijke uiterlijk wijzigt.

## **Veelgestelde vragen**

**Heeft het toepassen van een extern thema invloed op elke dia in de presentatie?**

Nee. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) wijst alleen de dia's toe die afhankelijk zijn van de geselecteerde master. Dia's die andere masters gebruiken behouden hun bestaande thema's.

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**

Ja. Gebruik de [SlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/slidethememanager/) van de dia en initialiseert zijn overschrijvings‑thema. De wijziging blijft lokaal voor die dia; andere dia's blijven hun bestaande thema's erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer u een dia verplaatst en de oorspronkelijke uitstraling wilt behouden, kloont u de bron‑master naar de bestemming en kloont u de dia met die master via [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/add_clone/) en [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/). Hiermee blijven de master, lay‑outs en het thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overschrijvingen?**

Gebruik [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) voor een dia‑ of lay‑out‑thema en de bijbehorende effectieve‑datamethodes voor formatobjecten zoals [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/) en [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/). Deze API's geven de berekende waarden terug nadat overerving en overschrijvingen zijn toegepast.