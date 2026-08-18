---
title: Hantera PowerPoint-presentationsteman i Python
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/python-net/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- ange tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behandla presentations-teman i Aspose.Slides för Python via .NET för att skapa, anpassa och konvertera PowerPoint-filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, typsnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt hänvisar till dessa delade definitioner istället för att lagra varje visuell egenskap som ett fast värde, så att en temaförändring kan uppdatera många objekt samtidigt.

I Aspose.Slides är temat på presentationsnivå tillgängligt via [Presentation.master_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/master_theme/). En presentation kan också innehålla temaarvoden på lägre nivåer. En master kan överskrida presentationstemat via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/masterthememanager/override_theme/), en layout kan överskrida sitt ärvda tema via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), och en enskild bild kan göra detsamma. I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentationstema, master‑överskott, layout‑överskott och bild‑överskott.

![Temakomponenter: färger, typsnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetssätten: inspektera ett tema, ändra färger och typsnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa av effektiva värden efter att arv och överskott har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/) exponerar temats [color_scheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/font_scheme/) och [format_scheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/format_scheme/) egenskaper. Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposterna kan variera.

Följande exempel läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effekstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden, och använd arbetsflödet för effektiva teman som visas senare i den här artikeln när layout‑ eller bild‑överskott kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och texter kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/python-net/aspose.slides/schemecolor/). När du ändrar motsvarande post i temats [ColorScheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/colorscheme/), lösts alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

Följande end‑to‑end‑exempel skapar en form som använder `ACCENT4`, ändrar temats `accent4`‑färg till röd, sparar presentationen, öppnar den igen och skriver ut den effektiva fyllningsfärgen:

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

Eftersom rektangeln fortfarande är länkad till `ACCENT4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemafärgen med en direkt färg på formen kommer senare förändringar av `accent4` inte längre påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att applicera färgtransformeringar. Aspose.Slides exponerar dessa transformeringar via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/colortransformoperation/).

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** – Huvudtemafärger.

**2** – Ljusare och mörkare varianter framtagna från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `ACCENT4`, applicerar luminans‑transformeringar på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `accent4` ändras senare beräknas de transformerade färgerna om från det nya `accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `ColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/python-net/aspose.slides/schemecolor/) använder `TEXT1`, `BACKGROUND1`, `TEXT2` och `BACKGROUND2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/colorscheme/) exponerar samma temaplatser som `dark1`, `light1`, `dark2` och `light2`. Mappningen är fast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som dynamiskt konverteras från en form till en annan.

## **Ändra tematypsnitt**

Ett tematypsnittsschema innehåller en huvudtypsnittssamling för rubriker och en sekundär typsnittssamling för brödtext. Egenskaperna [FontScheme.major](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/major/) och [FontScheme.minor](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/minor/) exponerar dessa samlingar.

PowerPoint‑kompatibla tematypsnittsidenterare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubrikfont Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasien (Minor East Asian Font)
* `+mj-ea` – Rubrikfont Östasien (Major East Asian Font)

Följande exempel skapar en rubrik som använder det stora latinska tematypsnittet och en brödtextlinje som använder det lilla latinska tematypsnittet. Därefter ändras tematypsnitten och resultatet sparas:

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

Rubriken följer det stora typsnittet och brödtexten följer det lilla typsnittet. Text som har ett explicit typsnittnamn istället för en temaidentifierare byter inte automatiskt när tematypsnittsschemat ändras.

{{% alert color="info" title="Tips" %}}

För mer information om presentations­typsnitt, se [PowerPoint Fonts](/slides/sv/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Det finns två vanliga arbetsflöden, och de löser olika problem.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern in i mål‑presentationen med [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/add_clone/), klona sedan bilden med [SlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_clone/) och den klonade mastern. Detta bär med sig mastern, dess layouter och det associerade temat tillsammans.

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

Detta är det föredragna arbetsflödet när källbilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad mål‑master kan förändra temadrivna färger, typsnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste behålla sin nuvarande master och layout, initiera ett bild‑nivå‑överskott från källtemat. Metoderna [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) och [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopierar de tre huvudtema‑komponenterna till överskottet.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvt av andra bilder. För att ta bort det lokala överskottet och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa ett tema‑överskott på en layout**

Ett layout‑nivå‑överskott gäller för bilder som använder den layouten, såvida inte en viss bild har ett eget överskott. Samma initieringsmetoder kan användas via layoutens [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma basdesign, ett layout‑överskott när en layoutfamilj behöver annan styling, och ett bild‑överskott endast för egentliga undantag. Överdrivna bild‑nivå‑överskott gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan visa fler bakgrundsalternativ i sitt gränssnitt än antalet fyllningsdefinitioner som fysiskt lagras i denna samling, eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint‑bakgrundsstilsgalleri för ett presentationstema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och det aktuella [Background.style_index](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/style_index/). `style_index` använder `0` för ingen temafyllning; positiva värden är referenser till temats bakgrundsstil. Detta skiljer sig från indexering av en Python‑samling där `[0]` betyder den första lagrade posten. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antalet tillgängliga bakgrundsfyllningar, tilldelar en temabakgrundsreferens till den första mastern och sparar presentationen:

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

Det synliga resultatet beror på temaposteringen som mastern refererar till och på eventuella bakgrundsöverskott på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av enbart master‑bakgrunden ha ingen effekt på den bilden. Använd [Background.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/get_effective/) när du behöver veta den slutgiltiga bakgrunden efter arv.

{{% alert color="warning" title="Varning" %}}

Behandla inte `style_index` som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastildefinitioner är presentationsspecifika.

{{% /alert %}}

{{% alert color="info" title="Tips" %}}

För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/python-net/presentation-background/).

{{% /alert %}}

## **Uppdatera temats effekter**

Ett temaformatschema innehåller separata samlingar för [FormatScheme.fill_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/line_styles/) och [FormatScheme.effect_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/effect_styles/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men koden bör inspektera varje samling istället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter som tillämpas på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i Python är samlingsindexen nollbaserade: `[0]` är den första lagrade stilen och `[2]` är den tredje. En forms stilreferens‑index är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar till den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar en yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar till dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med avstånd 10 punkter. Det exakt visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje, fyllning och skugga](presentation-design_11.png)

## **Läs av effektiva temavärden**

Råa temaobjekt visar vad som är definierat på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala överskott har lösts. För en bild, anropa [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). För en bakgrund, använd [Background.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/get_effective/), och för en fyllning, använd [FillFormat.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/get_effective/).

Följande exempel läser det effektiva temat, bakgrunden och den första formens fyllning från en bild:

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

Använd effektiva data för diagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.master_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/master_theme/), kan du missa ett master‑, layout‑, bild‑ eller form‑överskott som förändrar det slutgiltiga utseendet.

## **FAQ**

**Kan jag tillämpa ett tema på en enskild bild utan att ändra mastern?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/slidethememanager/) och initiera dess överskottstema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess ursprungliga utseende, klona käll‑mastern till destinationen och klona bilden med den mastern med [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/add_clone/) och [SlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_clone/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och överskott?**

Använd [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) för ett bild‑ eller layout‑tema och motsvarande effektiva‑data‑metoder för formatobjekt som [Background.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/get_effective/) och [FillFormat.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/get_effective/). Dessa API:er returnerar de lösta värdena efter att arv och överskott har tillämpats.