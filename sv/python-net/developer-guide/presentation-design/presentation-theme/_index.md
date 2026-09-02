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
- externt tema
- THMX
- temafärg
- extra palett
- temateckensnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Mästra presentationsteman i Aspose.Slides för Python via .NET för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentations­tema definierar en koordinerad uppsättning av färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Temamedvetna objekt refererar till dessa delade definitioner istället för att lagra varje visuellt egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt samtidigt.

I Aspose.Slides är temat på presentationsnivå tillgängligt via egenskapen [Presentation.master_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/master_theme/). En presentation kan också innehålla temaarvoder på lägre nivåer. En master kan åsidosätta presentations‑temat via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/masterthememanager/override_theme/), en layout kan åsidosätta sitt ärvda tema via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), och en enskild bild kan göra detsamma. I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentations‑tema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Temakomponenter: färger, teckensnitt, bakgrundsstilar och effekter](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effektstilar samt läsa effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

[MasterTheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/)‑objektet exponerar temats [color_scheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/font_scheme/) och [format_scheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/mastertheme/format_scheme/) egenskaper. Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtemats egenskaper och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera master‑bilder, anta inte att varje bild har samma effektiva tema. Inspektera den master som är kopplad till bilden, och använd arbetsflödet för effektiva teman som visas senare i den här artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Temamedvetna fyllningar, linjer och text kan referera till en logisk färg från [SchemeColor](https://reference.aspose.com/slides/sv/python-net/aspose.slides/schemecolor/)‑enumerationen. När du ändrar motsvarande post i temats [ColorScheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/colorscheme/), uppdateras alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

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

Eftersom rektangeln förblir länkad till `ACCENT4` blir dess synliga färg röd efter att temat har ändrats. Om du ersätter schemafärgen med en direkt färg på formen, kommer senare ändringar av `accent4` inte längre påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformationer. Aspose.Slides exponerar dessa transformationer via [ColorTransformOperation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/colortransformoperation/)‑enumerationen.

![Huvudtemafärger och ljusare samt mörkare färger genererade från den extra paletten](additional-palette-colors.png)

**1** - Huvudtemafärger.  

**2** - Ljusa och mörka varianter som produceras från huvudtemafärgerna.

Följande exempel skapar sex rektanglar baserade på `ACCENT4`, tillämpar luminans‑transformationer på fem av dem och sparar resultatet:

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

Dessa varianter förblir baserade på temafärgen. Om `accent4` ändras senare räknas de transformerade färgerna om från det nya `accent4`‑värdet.

### **Mappa `SchemeColor`‑värden till `ColorScheme`‑platser**

[SchemeColor](https://reference.aspose.com/slides/sv/python-net/aspose.slides/schemecolor/)‑enumerationen använder `TEXT1`, `BACKGROUND1`, `TEXT2` och `BACKGROUND2`, medan [ColorScheme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/colorscheme/) exponerar samma temaplatser som `dark1`, `light1`, `dark2` och `light2`. Mappningen är fast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Dessa är alternativa namn för samma temaplatser; de är inte värden som omvandlas dynamiskt från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller ett huvudteckensnitt för rubriker och ett sekundärt teckensnitt för brödtext. [FontScheme.major](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/major/) och [FontScheme.minor](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/fontscheme/minor/) egenskaperna exponerar dessa uppsättningar.

PowerPoint‑kompatibla temateckensnittsidentifierare kan användas i textformatering:

* `+mn-lt` - Brödtextteckensnitt Latin (Minor Latin Font)
* `+mj-lt` - Rubrikteckensnitt Latin (Major Latin Font)
* `+mn-ea` - Brödtextteckensnitt East Asian (Minor East Asian Font)
* `+mj-ea` - Rubrikteckensnitt East Asian (Major East Asian Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑temateckensnittet och en brödtext‑rad som använder sekundärt Latin‑temateckensnitt. Det ändrar sedan temateckensnitten och sparar resultatet:

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

Rubriken följer huvudteckensnittet och brödtexten följer sekundärt teckensnitt. Text som har ett explicit teckensnittsnamn istället för en temaidentifierare kommer inte automatiskt att bytas när temateckensnittsschemat ändras.

Huvud‑ och sekundära teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script‑Specific Theme Fonts](/slides/sv/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tips" %}}
För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en master‑beroende bilder**

Använd [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj masteren från [Presentation.masters](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/masters/)‑samlingen, som implementerar [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/), och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda masteren.  
2. Tillämpar det externa temat på den nya masteren.  
3. Tilldelar den nya masteren till alla bilder som tidigare berodde på den valda masteren.  
4. Returnerar den nyss skapade [IMasterSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första masteren och sparar presentationen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Ett ogiltigt, korrupt eller ej stödjande tema kan orsaka [PptxException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxexception/) eller en av dess formatrelaterade underklasser. Validera sökvägar som tillhandahålls av användare, hantera fel vid filsystemstillgång och spara presentationen först efter att temat framgångsrikt har tillämpats.

Endast de bilder som berodde på den valda masteren omplaceras. Bilder som är kopplade till andra master‑bilder behåller sina befintliga master‑bilder och teman. Temamedvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrad. Åsidosättningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya masteren.

Temat kan referera till teckensnitt som inte finns tillgängliga i körmiljön. För konsekvent rendering och export, installera de nödvändiga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/python-net/custom-font/), eller konfigurera [font substitution](/slides/sv/python-net/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en filsökväg till en `.thmx`‑fil och kräver inte att man manuellt skapar temåsidosättningar på bild‑ eller layoutnivå.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta master‑bilden inte är känd i förväg, hämta den från en representativ bild via [Slide.layout_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/layout_slide/) och [LayoutSlide.master_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/master_slide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två sektioner för att lokalisera deras master‑bilder och tillämpar ett annat externt tema på varje grupp:

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

Det första anropet påverkar bara de bilder som berodde på `first_group_master`, och det andra anropet påverkar bara de bilder som berodde på `second_group_master`. Bilder som tillhör någon annan master förändras inte.

### **Bevara ett källtema när man flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑masteren till målpresentationen med [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/add_clone/), klona sedan bilden med [SlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_clone/) och den klonade master‑bilden. Detta för med sig master‑bilden, dess layouter och det tillhörande temat tillsammans.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll till en orelaterad destinations‑master kan ändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa tema‑värden på en befintlig bild**

Om mål‑bilden måste förbli på sin nuvarande master‑ och layout‑nivå, initiera en bild‑nivå‑åsidosättning från käll‑temat. Metoderna [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), och [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som används av den bilden utan att ändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa en temåsidosättning på en layout**

En layout‑nivå‑åsidosättning gäller för bilder som använder den layouten, såvida inte en viss bild har sin egen åsidosättning. Samma initieringsmetoder kan användas via layoutens [LayoutSlideThemeManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑åsidosättning när en layout‑familj behöver annan stil, och en bild‑åsidosättning endast för verkliga undantag. Överdrivna bild‑nivå‑åsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan presentera fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i denna samling eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint bakgrundsstils galleri för ett presentations‑tema](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.style_index](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/style_index/). `style_index` använder `0` för ingen tematisk fyllning; positiva värden är temabakgrund‑stil‑referenser. Detta skiljer sig från att indexera en Python‑samling direkt, där `[0]` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

Följande exempel rapporterar antal tillgängliga bakgrundsfyllningar, tilldelar en tematisk bakgrundsreferens till den första masteren och sparar presentationen:

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

Det synliga resultatet beror på temaposten som refereras av master‑bilden och på eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av enbart master‑bakgrunden lämna den bilden oförändrad. Använd [Background.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/get_effective/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Varning" %}}
Behandla inte `style_index` som ett nollbaserat kollektionsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma visuella utseende i en annan fil; temastildefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tips" %}}
För direkt bakgrundsformatering och bakgrunds­ärvning, se [Presentation Background](/slides/sv/python-net/presentation-background/).
{{% /alert %}}

## **Uppdatera temats effekter**

Ett temaformat‑schema innehåller separata [FormatScheme.fill_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/line_styles/) och [FormatScheme.effect_styles](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/formatscheme/effect_styles/)‑samlingar. Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men kod bör inspektera varje samling i stället för att anta ett fast antal.

![Subtila, måttliga och intensiva temaeffekter tillämpade på samma form](presentation-design_10.png)

När du får åtkomst till dessa samlingar i Python är samlingsindexet nollbaserat: `[0]` är den första lagrade stilen och `[2]` är den tredje. En forms stil‑referensindex är ett separat koncept, exponerat via [IShapeStyle](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapestyle/). Att modifiera en temastil påverkar former som refererar den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar ett yttre skugga i den tredje effektstilen och sparar resultatet:

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

För former som refererar dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen blir solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar till och om direkt formatering åsidosätter temat.

![Temaeffektstilar efter ändring av linje, fyllning och skugga](presentation-design_11.png)

## **Läs effektiva temavärden**

Rå temobjekt visar vad som definierats på en viss nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter att arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). För en bakgrund, använd [Background.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/get_effective/), och för en fyllning, använd [FillFormat.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/get_effective/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.master_theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/master_theme/), kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) omfördelar endast de bilder som beror på den valda masteren. Bilder som använder andra master‑bilder behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master‑bilden?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/slidethememanager/) och initiera dess åsidosättande tema. Ändringen förblir lokal för den bilden; andra bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona käll‑masteren till destinationen och klona bilden med den master‑bilden via [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/add_clone/) och [SlideCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/add_clone/). Detta håller master‑bilden, layouterna och temat tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) för en bild‑ eller layout‑tema och de motsvarande effektiva‑data‑metoderna för formatobjekt såsom [Background.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/background/get_effective/) och [FillFormat.get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/get_effective/). Dessa API‑er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.