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
- thema-lettertype
- thema-stijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor Python via .NET om PowerPoint-bestanden te maken, aanpassen en converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert een gecoördineerde set van kleuren, lettertypen, achtergrondstijlen, vullingen, lijnen en effecten. Thema‑bewuste objecten verwijzen naar deze gedeelde definities in plaats van elke visuele eigenschap als een vaste waarde op te slaan, zodat een themawijziging veel objecten tegelijk kan bijwerken.

In Aspose.Slides is het thema op presentatieniveau beschikbaar via de [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) eigenschap. Een presentatie kan ook themaatvoeringen op lagere niveaus bevatten. Een master kan het presentatiethema overschrijven via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/masterthememanager/override_theme/), een lay‑out kan zijn geërfde thema overschrijven via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), en een individuele slide kan hetzelfde doen. In de praktijk wordt het effectieve thema voor een slide bepaald via deze overervingsketen: presentatiethema, master‑override, lay‑out‑override en slide‑override.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

De secties hieronder laten de meest voorkomende themaworkflows zien: een thema inspecteren, kleuren en lettertypen wijzigen, een thema kopiëren of toepassen, achtergrond‑ en effectstijlen bijwerken, en effectieve waarden lezen nadat overerving en overrides zijn verwerkt.

## **Een Thema Inspecteren**

Het [MasterTheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/) object stelt de [color_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/font_scheme/) en [format_scheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/mastertheme/format_scheme/) van het thema bloot. Het inspecteren van deze collecties voordat je ze wijzigt is vooral nuttig wanneer een presentatie uit een externe bron komt, omdat het aantal en de inhoud van stijl‑items kan variëren.

Het volgende voorbeeld leest de belangrijkste themaeigenschappen en meldt hoeveel achtergrond‑, vul‑, lijn‑ en effectstijlen er in het thema zijn opgeslagen:

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

Als een bestand meerdere masters gebruikt, ga er dan niet van uit dat elke slide hetzelfde effectieve thema heeft. Inspecteer de master die bij de slide hoort, en gebruik de effectieve‑thema‑workflow die later in dit artikel wordt getoond wanneer lay‑out‑ of slide‑overrides aanwezig kunnen zijn.

## **Themakleuren Wijzigen**

Thema‑bewuste vullingen, lijnen en tekst kunnen verwijzen naar een logische kleur uit de [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) enumeratie. Wanneer je de overeenkomstige invoer in de thema‑[ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/) wijzigt, worden alle objecten die nog steeds naar die themakleur verwijzen, opgehaald tegen de nieuwe waarde. Objecten die een directe RGB‑kleur gebruiken, worden niet aangepast door een thema‑kleurupdate.

Het volgende end‑to‑end voorbeeld maakt een vorm die `ACCENT4` gebruikt, wijzigt de thema‑`accent4`‑kleur naar rood, slaat de presentatie op, opent deze opnieuw, en print de effectieve vulkleur:

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

Omdat het rechthoekige object gekoppeld blijft aan `ACCENT4`, wordt de zichtbare kleur rood nadat het thema is gewijzigd. Als je de schema‑kleur vervangt door een directe kleur op de vorm, hebben latere wijzigingen aan `accent4` geen invloed meer op die vulling.

### **Kleuren Gebruiken uit het Aanvullende Palet**

PowerPoint haalt lichtere en donkere varianten uit een themakleur door kleurtransformaties toe te passen. Aspose.Slides maakt deze transformaties beschikbaar via de [ColorTransformOperation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/colortransformoperation/) enumeratie.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hoofdkleuren van het thema.

**2** – Lichtere en donkerdere varianten die uit de hoofdkleuren van het thema worden gegenereerd.

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

### **`SchemeColor`‑waarden Toewijzen aan `ColorScheme`‑posities**

De [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) enumeratie gebruikt `TEXT1`, `BACKGROUND1`, `TEXT2` en `BACKGROUND2`, terwijl [ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/) dezelfde themaposities blootlegt als `dark1`, `light1`, `dark2` en `light2`. De toewijzing is vast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dit zijn alternatieve namen voor dezelfde themaposities; het zijn geen waarden die dynamisch van de ene vorm naar de andere worden omgezet.

## **Thema‑Lettertypen Wijzigen**

Een thema‑lettertype‑schema bevat een grote letterset voor koppen en een kleine letterset voor body‑tekst. De eigenschappen [FontScheme.major](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/major/) en [FontScheme.minor](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/fontscheme/minor/) geven die sets bloot.

PowerPoint‑compatibele thema‑lettertype‑identifiers kunnen worden gebruikt bij tekstopmaak:

* `+mn‑lt` – Body Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading Font Latin (Major Latin Font)
* `+mn‑ea` – Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading Font East Asian (Major East Asian Font)

Het volgende voorbeeld maakt één kop die het grote Latijnse themalettertype gebruikt en één body‑regel die het kleine Latijnse themalettertype gebruikt. Het wijzigt vervolgens de themaletters en slaat het resultaat op:

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

De kop volgt het grote lettertype en de body‑tekst volgt het kleine lettertype. Tekst met een expliciete lettertype‑naam in plaats van een thema‑identifier zal niet automatisch wisselen wanneer het thema‑lettertype‑schema verandert.

De grote en kleine lettertypecollecties kunnen bovendien lettertype‑toewijzingen bevatten voor individuele schrijfsystemen, zoals Cyrillisch, Arabisch, Japans, Georgisch en Thaana. Om deze toewijzingen te inspecteren, toe te voegen, te vervangen of te verwijderen, zie [Script‑Specific Theme Fonts](/slides/nl/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Voor meer informatie over presentatieletters, zie [PowerPoint Fonts](/slides/nl/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Een Thema Kopiëren of Toepassen**

De onderstaande workflows lossen verschillende thema‑gerelateerde problemen op.

### **Een Extern Thema Toepassen op Slides die Afhankelijk Zijn van een Master**

Gebruik [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) wanneer je een PowerPoint‑themabestand (`.thmx`) hebt en elke slide die van een bepaalde master afhangt opnieuw wilt stijlen. Selecteer de master uit de [Presentation.masters](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/masters/) collectie, die een [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/) implementeert, en geef het pad van het themabestand door aan de methode.

De methode voert de volgende handelingen uit:

1. Maakt een nieuwe master‑slide gebaseerd op de geselecteerde master.
1. Past het externe thema toe op de nieuwe master.
1. Wijs de nieuwe master toe aan alle slides die vóórheen afhankelijk waren van de geselecteerde master.
1. Retourneert de nieuw aangemaakte [IMasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/).

Het volgende voorbeeld past een extern thema toe op de slides die afhankelijk zijn van de eerste master en slaat de presentatie op:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Een ongeldig, beschadigd of niet‑ondersteund thema kan een [PptxException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxexception/) of een van zijn format‑gerelateerde subklassen veroorzaken. Valideer paden die door gebruikers worden opgegeven, behandel fouten bij bestands‑systeemtoegang, en sla de presentatie alleen op nadat het thema met succes is toegepast.

Alleen de slides die afhankelijk waren van de geselecteerde master worden opnieuw toegewezen. Slides die bij andere masters horen behouden hun bestaande masters en thema’s. Thema‑bewuste kleuren, lettertypen, vullingen, lijnen, achtergronden en effecten worden opgehaald tegen het externe thema. Direct toegewezen kleuren, lettertypen, vullingen en andere expliciete opmaak kunnen ongewijzigd blijven. Overrides op lay‑out‑niveau en slide‑niveau kunnen ook voorrang hebben op waarden die van de nieuwe master worden geërfd.

Het thema kan verwijzen naar lettertypen die niet beschikbaar zijn in de runtime‑omgeving. Voor consistente weergave en export, installeer de vereiste lettertypen, lever ze via [custom font sources](/slides/nl/python-net/custom-font/), of configureer [font substitution](/slides/nl/python-net/font-substitution/).

Dit is een directe master‑niveau workflow: de methode accepteert een bestandspad naar een `.thmx` bestand en vereist geen handmatige creatie van theme‑overrides op slide‑ of lay‑out‑niveau.

### **Verschillende Externe Thema’s Toepassen in een Multi‑Master Presentatie**

Wanneer de relevante master vooraf niet bekend is, haal deze dan op via een representatieve slide met [Slide.layout_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/layout_slide/) en [LayoutSlide.master_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/master_slide/). Bewaar de originele master‑referenties voordat je thema’s toepast omdat elke aanroep een nieuwe master in de presentatie aanmaakt.

Het volgende voorbeeld gebruikt slides uit twee secties om hun masters te vinden en past een verschillend extern thema toe op elke groep:

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

De eerste aanroep betrekt alleen slides die afhankelijk waren van `first_group_master`, en de tweede aanroep betrekt alleen slides die afhankelijk waren van `second_group_master`. Slides die bij een andere master horen, worden niet opnieuw gestyled.

### **Een Bron‑Thema Behouden bij Het Verplaatsen van Slides**

Wil je een slide naar een andere presentatie verplaatsen en het oorspronkelijke ontwerp behouden, kloon dan de bron‑master in de doelfolder met [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/add_clone/), kloon vervolgens de slide met [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) en de gekloonde master. Dit brengt de master, zijn lay‑outs en het bijbehorende thema samen.

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

Dit is de voorkeursworkflow wanneer de bron‑slide er in de bestemming exact hetzelfde uit moet zien. Het simpelweg kloont van inhoud op een niet‑gerelateerde doelfolder‑master kan thema‑gedreven kleuren, lettertypen, achtergronden en effecten wijzigen.

### **Thema‑Waarden Toepassen op een Bestaande Slide**

Moet de doelslide op zijn huidige master en lay‑out blijven, initialiseert dan een slide‑niveau override vanuit het bron‑thema. De methoden [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) en [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiëren de drie hoofdthema‑componenten naar de override.

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

Dit wijzigt het thema dat die slide gebruikt zonder het thema dat andere slides erven te veranderen. Om de lokale override te verwijderen en terug te keren naar geërfde waarden, roep [OverrideTheme.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/overridetheme/clear/) aan.

### **Een Thema‑Override Toepassen op een Lay‑out**

Een lay‑out‑niveau override geldt voor alle slides die die lay‑out gebruiken, tenzij een specifieke slide een eigen override heeft. Dezelfde initialisatiemethoden kunnen worden gebruikt via de lay‑out‑[LayoutSlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Gebruik een master‑ of presentatiethema wanneer veel lay‑outs en slides hetzelfde basisonwerp moeten delen, een lay‑out‑override wanneer één lay‑outfamilie een andere styling nodig heeft, en een slide‑override alleen voor echte uitzonderingen. Overmatige slide‑niveau overrides maken latere globale themawijzigingen moeilijker te voorspellen.

## **Thema‑Achtergrondstijlen Bijwerken**

De achtergrond‑vullingen van het thema worden opgeslagen in [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan in de UI meer achtergrondkeuzes tonen dan het aantal vuldefinities dat feitelijk in deze collectie is opgeslagen, omdat de UI thema‑vullingen kan combineren met themakleuren en andere stijl‑referenties.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Voordat je een achtergrondstijl gebruikt, inspecteer je de opgeslagen collectie en de huidige [Background.style_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/style_index/). `style_index` gebruikt `0` voor geen themavulling; positieve waarden zijn verwijzingen naar themabackground‑stijlen. Dit verschilt van het indexeren van een Python‑collectie, waarbij `[0]` het eerste opgeslagen item betekent. Ga er niet van uit dat elke presentatie evenveel achtergrond‑vullingsstijlen bevat.

Het volgende voorbeeld rapporteert het aantal beschikbare achtergrondvullingen, wijst een thematische achtergrondreferentie toe aan de eerste master, en slaat de presentatie op:

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

Het zichtbare resultaat hangt af van de thema‑entry waar de master naar verwijst en van eventuele achtergrond‑overrides op lay‑out‑ of slide‑niveau. Als een slide een eigen achtergrond gebruikt, kan het wijzigen van alleen de master‑achtergrond die slide niet beïnvloeden. Gebruik [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/) wanneer je de uiteindelijke achtergrond na overerving wilt weten.

{{% alert color="warning" title="Warning" %}}

Behandel `style_index` niet als een nul‑gebaseerde collectie‑index. Vermijd ook het hard‑coderen van een stijlnummer uit één bestand en ervan uitgaan dat het dezelfde weergave heeft in een ander bestand; themastijl‑definities zijn specifiek per presentatie.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Voor directe achtergrondopmaak en achtergrond‑overerving, zie [Presentation Background](/slides/nl/python-net/presentation-background/).

{{% /alert %}}

## **Thema‑Effecten Bijwerken**

Een thema‑formaat‑schema bevat aparte collecties voor [FormatScheme.fill_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/line_styles/) en [FormatScheme.effect_styles](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/effect_styles/). Veelvoorkomende Office‑thema’s bevatten vaak drie hoofdstijl‑items die visueel overeenkomen met subtiele, gematigde en intensieve opmaak, maar code moet iedere collectie inspecteren in plaats van een vaste telling aan te nemen.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wanneer je deze collecties in Python benadert, is de collectie‑index nul‑gebaseerd: `[0]` is de eerste opgeslagen stijl en `[2]` de derde. Een vorm‑stijl‑referentie‑index is een apart concept, blootgelegd via [IShapeStyle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapestyle/). Het wijzigen van een themastijl beïnvloedt vormen die die stijl refereren; vormen met directe opmaak kunnen ongewijzigd blijven.

Het volgende voorbeeld controleert of de benodigde stijl‑items bestaan, wijzigt de eerste lijnstijl, wijzigt de derde vulstijl, activeert een buitenste schaduw in de derde effectstijl, en slaat het resultaat op:

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

Voor vormen die deze posities refereren, wordt de eerste themalijnstijl rood, de derde themavulstijl een effen bosgroen, en krijgt de derde effectstijl een buitenste schaduw met een afstand van 10 punten. Het exacte visuele resultaat blijft afhankelijk van welke stijlposities elke vorm refereren en of directe opmaak de theme‑waarde overschrijft.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Bepalen of een Effectieve Vulling een Thematische Kleur Gebruikt**

Een vulling kan direct op een object worden opgeslagen of worden geërfd van een alinea, lay‑out, master, themastijl of een ander formatteringsniveau. Roep [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/) aan om die hiërarchie op te lossen tot een onbewerkbare [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/). Controleer eerst [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Alleen wanneer dit `FillType.SOLID` is, kun je de eigenschappen van een effen vulling lezen.

Voor een solide vulling geeft [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) de definitieve gerenderde RGB‑waarde na overerving, themalookup en kleurovergangen. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) levert de overeenkomstige logische [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) slot, zoals `TEXT1` of `ACCENT6`. Een waarde van `SchemeColor.NOT_DEFINED` betekent dat de effectieve solide vulling niet gebaseerd is op een schema‑kleur. In een workflow waarin vullingen ofwel themakleuren ofwel directe RGB‑kleuren zijn, identificeert deze waarde een directe RGB‑vulling.

Gebruik de lokale [IColorFormat.scheme_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/icolorformat/scheme_color/) waarde niet alleen om een vulling te classificeren. Bijvoorbeeld, een tekstgedeelte kan geen lokaal gedefinieerde schema‑kleur hebben, waardoor de lokale waarde `NOT_DEFINED` is, terwijl de effectieve vulling een themakleur erft en resolveert naar `TEXT1` of `ACCENT6`. Omgekeerd vertelt `solid_fill_scheme_color` je welke logische themaslot de effectieve kleur heeft opgeleverd, maar niet van welk formatteringsniveau (object, alinea, lay‑out, master, …) deze afkomstig is.

Het volgende voorbeeld laadt een presentatie, controleert zowel vorm‑vullingen als tekst‑gedeelte‑vullingen, print elke uiteindelijke RGB‑waarde en de bijbehorende schema‑kleur, en markeert solide vullingen die geen themakleur‑veranderingen volgen:

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

De `NOT_DEFINED`‑tak levert een audit‑lijst van solide vullingen die niet reageren op wijzigingen in themakleur‑slots. Bekijk deze objecten wanneer een presentatie een nieuw merkschema moet volgen. De gerapporteerde RGB‑waarde toont nog steeds de huidige uitstraling, terwijl de schema‑waarde aangeeft of die uitstraling met het thema is verbonden.

Effectieve‑formaatobjecten zijn momentopnamen. Nadat je het presentatiethema, een thema‑override of enige geërfde opmaak wijzigt, roep je opnieuw `get_effective` aan en lees je een nieuw `IFillFormatEffectiveData` object voordat je kleuren vergelijkt of rapporteert.

## **Effectieve Thema‑Waarden Lezen**

Ruwe thema‑objecten vertellen wat er op een bepaald niveau is gedefinieerd. Effectieve waarden vertellen wat een slide of vorm daadwerkelijk gebruikt nadat overerving en lokale overrides zijn verwerkt. Voor een slide roep je [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) aan. Voor een achtergrond gebruik je [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/), en voor een vulling [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/).

Het volgende voorbeeld leest het effectieve thema, de achtergrond en de eerste vorm‑vulling van een slide:

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

Gebruik effectieve data voor renderdiagnostiek, validatie en vergelijkingen. Als je alleen [Presentation.master_theme](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/master_theme/) inspecteert, kun je een master, lay‑out, slide of vorm‑override missen die het uiteindelijke uiterlijk wijzigt.

## **FAQ**

**Heeft het toepassen van een extern thema invloed op elke slide in de presentatie?**

Nee. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) wijst alleen de slides opnieuw toe die afhankelijk zijn van de geselecteerde master. Slides die andere masters gebruiken behouden hun bestaande thema’s.

**Kan ik een thema toepassen op één enkele slide zonder de master te wijzigen?**

Ja. Gebruik de slide‑[SlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/slidethememanager/) en initialise­er zijn override‑thema. De wijziging blijft lokaal voor die slide; andere slides blijven hun bestaande thema’s erven.

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

Wanneer je een slide verplaatst en de oorspronkelijke weergave wilt behouden, kloon dan de bron‑master in de bestemming en kloon de slide met die master via [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/add_clone/) en [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/). Hiermee blijven master, lay‑outs en thema samen.

**Hoe kan ik de effectieve waarden zien na overerving en overrides?**

Gebruik [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) voor een slide‑ of lay‑out‑thema en de corresponderende effectieve‑data‑methoden voor format‑objecten zoals [Background.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/background/get_effective/) en [FillFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/get_effective/). Deze API’s retourneren de opgeloste waarden nadat overerving en overrides zijn toegepast.