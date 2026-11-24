---
title: "Hantera PowerPoint‑presentationsteman i Python"
linktitle: "Presentationstema"
type: docs
weight: 10
url: /sv/python-net/presentation-theme/
keywords:
- "PowerPoint‑tema"
- "presentations‑tema"
- "bildtema"
- "sätt tema"
- "ändra tema"
- "hantera tema"
- "externt tema"
- THMX
- "temafärg"
- "extra palett"
- "temateckensnitt"
- "temastil"
- "temaeffekt"
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera presentations‑teman i Aspose.Slides för Python via .NET för att skapa, anpassa och konvertera PowerPoint‑filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar en samordnad uppsättning färger, teckensnitt, bakgrundsstilar, fyllningar, linjer och effekter. Tema‑medvetna objekt refererar till dessa gemensamma definitioner istället för att lagra varje visuell egenskap som ett fast värde, så en temaförändring kan uppdatera många objekt på en gång.

I Aspose.Slides är presentationens tema tillgängligt via egenskapen [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). En presentation kan också innehålla temauppåsättningar på lägre nivåer. En master kan åsidosätta presentations‑temat med [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), ett layout kan åsidosätta sitt ärvda tema med [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), och en enskild bild kan göra detsamma. I praktiken löses det effektiva temat för en bild genom denna arvskedja: presentationstema, master‑åsidosättning, layout‑åsidosättning och bild‑åsidosättning.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Avsnitten nedan visar de vanligaste temaarbetsflödena: inspektera ett tema, ändra färger och teckensnitt, kopiera eller tillämpa ett tema, uppdatera bakgrunds‑ och effekstilar samt läsa av effektiva värden efter att arv och åsidosättningar har lösts.

## **Inspektera ett tema**

Objektet [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) exponerar temats [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) och [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) egenskaper. Att inspektera dessa samlingar innan de ändras är särskilt användbart när en presentation kommer från en extern källa eftersom antalet och innehållet i stilposter kan variera.

Följande exempel läser huvudtema‑egenskaperna och rapporterar hur många bakgrunds‑, fyllnings‑, linje‑ och effektstilar som lagras i temat:

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

Om en fil använder flera masters, anta inte att varje bild har samma effektiva tema. Inspektera den master som är associerad med bilden och använd arbetsflödet för effektiva teman som visas senare i den här artikeln när layout‑ eller bild‑åsidosättningar kan finnas.

## **Ändra temafärger**

Tema‑medvetna fyllningar, linjer och text kan referera till en logisk färg från uppräkningen [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). När du ändrar motsvarande post i temats [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) löses alla objekt som fortfarande refererar till den temafärgen mot det nya värdet. Objekt som använder en direkt RGB‑färg ändras inte av en temafärgsuppdatering.

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

Eftersom rektangeln förblir länkad till `ACCENT4` blir dess synliga färg röd efter att temat ändrats. Om du ersätter schema‑färgen med en direkt färg på formen kommer senare ändringar av `accent4` inte längre att påverka den fyllningen.

### **Använd färger från den extra paletten**

PowerPoint härleder ljusare och mörkare varianter från en temafärg genom att tillämpa färgtransformeringar. Aspose.Slides exponerar dessa transformationer via uppräkningen [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Huvudtemafärger.

**2** - Ljusare och mörkare varianter som produceras från huvudtemafärgerna.

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

### **Karta `SchemeColor`‑värden till `ColorScheme`‑platser**

Uppräkningen [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) använder `TEXT1`, `BACKGROUND1`, `TEXT2` och `BACKGROUND2`, medan [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) exponerar samma temaplatser som `dark1`, `light1`, `dark2` och `light2`. Kartläggningen är fast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Detta är alternativa namn för samma temaplatser; de är inte värden som konverteras dynamiskt från en form till en annan.

## **Ändra temateckensnitt**

Ett temateckensnittsschema innehåller en huvudteckensnittssamling för rubriker och en mindre teckensnittssamling för brödtext. Egenskaperna [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) och [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) exponerar dessa samlingar.

PowerPoint‑kompatibla temateckensnittsidénifierare kan användas i textformatering:

* `+mn-lt` – Brödtext Latin (Minor Latin Font)
* `+mj-lt` – Rubrik Latin (Major Latin Font)
* `+mn-ea` – Brödtext Östasien (Minor East Asian Font)
* `+mj-ea` – Rubrik Östasien (Major East Asian Font)
* `+mn-cs` – Brödtext Komplex Skript (Minor Complex Script Font)
* `+mj-cs` – Rubrik Komplex Skript (Major Complex Script Font)

Följande exempel skapar en rubrik som använder huvud‑Latin‑temateckensnittet och en brödtextrad som använder den mindre Latin‑temateckensnittet. Det ändrar sedan temateckensnitten och sparar resultatet:

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

Rubriken följer huvudteckensnittet och brödtexten följer det mindre teckensnittet. Text som har ett explicit teckensnittsnamn istället för ett temaidénifierare byter inte automatiskt när temateckensnittsschemat ändras.

De stora och små teckensnittssamlingarna kan också innehålla teckensnittsmappningar för enskilda skriftsystem, såsom kyrilliska, arabiska, japanska, georgiska och thaana. För att inspektera, lägga till, ersätta eller ta bort dessa mappningar, se [Script-Specific Theme Fonts](/slides/sv/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
För mer information om presentations‑teckensnitt, se [PowerPoint Fonts](/slides/sv/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Lös temateckensnittreferenser**

När du inspekterar text kan [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) innehålla en temareferens såsom `+mn-lt` istället för ett teckensnittsfamiljenamn. Anropa [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) med lämplig [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) för att lösa den referensen. Prefixen `+mj` och `+mn` väljer huvud‑ respektive mindre teckensnittssamlingar; suffixen `-lt`, `-ea` och `-cs` väljer deras Latin‑, Östasien‑ och Komplex‑Skript‑teckensnitt.

Skaffa det effektiva temat via [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) på det objekt vars tema gäller för den inspekterade texten. För vanlig text på en bild, använd `slide.create_theme_effective` så att kontexten inkluderar bildens ärvda tema och lokala åsidosättningar. När du inspekterar ett layout eller en master själv, använd dess eget effektiva tema. Anta inte att den första masterns tema gäller för varje bild.

Följande exempel skapar en textdel som explicit refererar till den mindre Latin‑teckensnittet. Det initierar ett bild‑teckensnittsschema via [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) och sätter de stora och små Latin‑familjerna till `Arial` respektive `Calibri`, vilket gör resultatet reproducerbart utan en indatafil.

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

Utmatningen är `+mn-lt -> Calibri` följt av `Verdana -> Verdana`. Den lagrade referensen förblir oförändrad, medan ett explicit familjenamn returneras som det är. Om delarna använde `+mj-lt` skulle den lösas till `Arial` i detta tema.

Att lösa en temareferens identifierar den teckensnittsfamilj som specificerats av temat. Det kontrollerar inte teckensnittstillgänglighet eller avgör vilken teckensnittfil som slutligen används efter ersättning eller glyf‑fallback under rendering. Se [Font Selection Sequence](/slides/sv/python-net/font-selection-sequence/) och [Font Substitution](/slides/sv/python-net/font-substitution/) för dessa separata steg.

## **Kopiera eller tillämpa ett tema**

Arbetsflödena nedan löser olika temarelaterade problem.

### **Tillämpa ett externt tema på en masters‑beroende bilder**

Använd [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) när du har en PowerPoint‑temafil (`.thmx`) och vill omstyla varje bild som beror på en viss master. Välj master från samlingen [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) och skicka temafilens sökväg till metoden.

Metoden utför följande operationer:

1. Skapar en ny master‑bild baserad på den valda mastern.
1. Tillämpa det externa temat på den nya mastern.
1. Tilldela den nya mastern till alla bilder som tidigare berodde på den valda mastern.
1. Returnerar den nyss skapade [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

Följande exempel tillämpar ett externt tema på de bilder som beror på den första mastern och sparar presentationen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Ett ogiltigt, korrupt eller ej stött tema kan orsaka [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) eller någon av dess format‑relaterade underklasser. Validera sökvägar som användare tillhandahåller, hantera filsystem‑åtkomstfel och spara presentationen först efter att temat har tillämpats framgångsrikt.

Endast de bilder som berodde på den valda mastern omfördelas. Bilder som är associerade med andra masters behåller sina befintliga masters och teman. Tema‑medvetna färger, teckensnitt, fyllningar, linjer, bakgrunder och effekter löses mot det externa temat. Direkt tilldelade färger, teckensnitt, fyllningar och annan explicit formatering kan förbli oförändrade. Åsidosättningar på layout‑ och bildnivå kan också ha företräde framför värden som ärvts från den nya mastern.

Temat kan referera till teckensnitt som inte finns tillgängliga i körningsmiljön. För konsekvent rendering och export, installera de nödvändiga teckensnitten, tillhandahåll dem via [custom font sources](/slides/sv/python-net/custom-font/), eller konfigurera [font substitution](/slides/sv/python-net/font-substitution/).

Detta är ett direkt master‑nivå‑arbetsflöde: metoden accepterar en sökväg till en `.thmx`‑fil och kräver inte att du manuellt skapar temåsåsidosättningar på bild‑ eller layoutnivå.

### **Tillämpa olika externa teman i en multi‑master‑presentation**

När den relevanta mastern inte är känd i förväg, hämta den från en representativ bild via [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) och [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Spara de ursprungliga master‑referenserna innan du tillämpar några teman eftersom varje anrop skapar en ny master i presentationen.

Följande exempel använder bilder från två avsnitt för att lokalisera deras masters och tillämpar ett annat externt tema på varje grupp:

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

Det första anropet påverkar endast de bilder som berodde på `first_group_master`, och det andra anropet påverkar endast de bilder som berodde på `second_group_master`. Bilder som tillhör någon annan master omstylar inte.

### **Bevara ett källtema när du flyttar bilder**

Om du vill flytta en bild till en annan presentation och bevara dess ursprungliga design, klona käll‑mastern till mål‑presentationen med [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), klona sedan bilden med [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) och den klonade mastern. Detta medför att mastern, dess layouter och det associerade temat följer med.

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

Detta är det föredragna arbetsflödet när käll‑bilden måste se likadan ut i destinationen. Att bara klona innehåll på en orelaterad destinations‑master kan förändra temadrivna färger, teckensnitt, bakgrunder och effekter.

### **Tillämpa temavärden på en befintlig bild**

Om mål‑bilden måste förbli på sin nuvarande master och layout, initiera en bild‑nivå‑åsidosättning från käll‑temat. Metoderna [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) och [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopierar de tre huvudtema‑komponenterna till åsidosättningen.

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

Detta ändrar temat som den bilden använder utan att förändra temat som ärvs av andra bilder. För att ta bort den lokala åsidosättningen och återgå till ärvda värden, anropa [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **Tillämpa en temåsåsidosättning på ett layout**

En layout‑nivå‑åsidosättning gäller för bilder som använder det layoutet, såvida en specifik bild inte har sin egen åsidosättning. Samma initieringsmetoder kan användas via layoutens [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Använd ett master‑ eller presentations‑tema när många layouter och bilder ska dela samma grunddesign, en layout‑åsidosättning när en layout‑familj behöver annan styling, och en bild‑åsidosättning endast för verkliga undantag. Överdrivna bild‑åsidosättningar gör senare globala temaförändringar svårare att förutsäga.

## **Uppdatera temats bakgrundsstilar**

Temats bakgrundsfyllningar lagras i [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint kan visa fler bakgrundsalternativ i sitt UI än antalet fyllningsdefinitioner som fysiskt lagras i den här samlingen eftersom UI kan kombinera temafyllningar med temafärger och andra stilreferenser.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Innan du använder en bakgrundsstil, inspektera den lagrade samlingen och den aktuella [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` använder `0` för ingen temafyllning; positiva värden är temabakgrund‑stilreferenser. Detta skiljer sig från att indexera en Python‑samling direkt, där `[0]` betyder det första lagrade objektet. Anta inte att varje presentation innehåller samma antal bakgrundsfyllningsstilar.

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

Det synliga resultatet beror på temapostens referens som mastern pekar på samt eventuella bakgrundsåsidosättningar på layout‑ eller bildnivå. Om en bild använder sin egen bakgrund kan en ändring av endast master‑bakgrunden missa den bilden. Använd [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) när du behöver veta den slutgiltiga bakgrunden efter att arv har tillämpats.

{{% alert color="warning" title="Warning" %}}
Behandla inte `style_index` som ett nollbaserat samlingsindex. Undvik också att hårdkoda ett stilnummer från en fil och anta att det har samma utseende i en annan fil; temastilsdefinitioner är presentationsspecifika.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
För direkt bakgrundsformatering och bakgrundsarv, se [Presentation Background](/slides/sv/python-net/presentation-background/).
{{% /alert %}}

## **Uppdatera temats effekter**

Ett temaförmátsschema innehåller separata samlingar för [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) och [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Vanliga Office‑teman innehåller ofta tre huvudsakliga stilposter som visuellt motsvarar subtil, måttlig och intensiv formatering, men koden bör inspektera varje samling istället för att anta ett fast antal.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

När du får åtkomst till dessa samlingar i Python är samlingsindexet nollbaserat: `[0]` är den första lagrade stilen och `[2]` är den tredje. En formes stil‑referensindex är ett separat koncept, exponerat via [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Att modifiera en temastil påverkar former som refererar den temastilen; former med direkt formatering kan förbli oförändrade.

Följande exempel kontrollerar att de nödvändiga stilposterna finns, ändrar den första linjestilen, ändrar den tredje fyllningsstilen, aktiverar ett yttre skuggelement i den tredje effektstilen och sparar resultatet:

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

För former som refererar dessa platser blir den första temalinjestilen röd, den tredje temafyllningsstilen solid skoggrön, och den tredje effektstilen får en yttre skugga med ett avstånd på 10 punkter. Det exakta visuella resultatet beror fortfarande på vilka stilplatser varje form refererar och om direkt formatering åsidosätter temat.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Välj temafyllnings‑ och linjestilar för en form**

En form kan välja sin fyllning och kontur oberoende via [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) och [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). För båda egenskaperna väljer index `1` den första posten i motsvarande temasamling (`fill_styles[0]` eller `line_styles[0]`), och index `2` väljer den andra posten.

Följande exempel definierar två fyllningar (guld och himmelblå) och två konturer (mörkblå på 6 pt och mörkröd på 12 pt) i standardtemat för en ny presentation. Det sparar bilden i tre steg så att du kan jämföra resultaten i PowerPoint.

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

| Initiala stilar | Ändra högra konturen | Redigera den första temafyllningen |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Att välja en annan linjestil ändrar bara den högra rektangelns kontur. Att redigera den första temafyllningen uppdaterar varje form som använder den. Här blir bara den vänstra rektangeln grön.

På en befintlig form kan en lokal fyllningsfärg, linjefärg eller linjebredd åsidosätta den delen av temastilen. Om en stilindexändring inte ger någon synlig effekt, kontrollera formens [direct formatting](/slides/sv/python-net/shape-formatting/).

## **Bestäm om en effektiv solid fyllning använder en temafärg**

En fyllning kan lagras direkt på ett objekt eller ärvas från ett stycke, layout, master, temastil eller en annan formateringsnivå. Anropa [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) för att lösa den hierarkin till ett oförändrat [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/). Kontrollera först [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Endast när den är `FillType.SOLID` bör du läsa de solid‑fyllnings‑egenskaperna.

För en solid fyllning returnerar [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) det slutliga renderade RGB‑värdet efter arv, temauppslagning och färgtransformeringar. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) returnerar motsvarande logiska [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/)‑slot, såsom `TEXT1` eller `ACCENT6`. Ett värde `SchemeColor.NOT_DEFINED` betyder att den effektiva solida fyllningen inte är baserad på en schemafärg. I ett arbetsflöde där fyllningar antingen är temafärger eller direkta RGB‑färger identifierar detta värde en direkt RGB‑fyllning.

Använd inte den lokala [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/)‑värdet ensamt för att klassificera en fyllning. Till exempel kan en textdel sakna en lokalt definierad schemafärg, så dess lokala värde är `NOT_DEFINED`, medan dess effektiva fyllning ärvs från ett tema och löser till `TEXT1` eller `ACCENT6`. Omvänt visar `solid_fill_scheme_color` vilken logisk temaplatsslot som producerade den effektiva färgen, men den anger inte om den sloten kom från objektet, stycket, layouten, mastern eller en annan nivå i formateringshierarkin.

Följande exempel laddar en presentation, granskar både form‑ och textdel‑fyllningar, skriver ut varje slutgiltigt RGB‑värde och associerad schemafärg, och markerar solida fyllningar som inte kommer att följa temafärgsändringar:

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

Grenen `NOT_DEFINED` ger en granskningslista över solida fyllningar som inte kommer att reagera på förändringar i temafärg‑slotar. Granska dessa objekt när en presentation måste följa en ny varumärkespalett. Det rapporterade RGB‑värdet visar fortfarande det aktuella utseendet, medan schema‑värdet förklarar om det utseendet är kopplat till temat.

Effektiva formatobjekt är ögonblicksbilder. Efter att temat för presentationen, en temåsåsidosättning eller någon ärvd formatering har ändrats, anropa `get_effective` igen och läs ett nytt `IFillFormatEffectiveData`‑objekt innan du jämför eller rapporterar färger.

## **Läs effektiva temavärden**

Råa temobjekt berättar vad som definierats på en specifik nivå. Effektiva värden visar vad en bild eller form faktiskt använder efter arv och lokala åsidosättningar har lösts. För en bild, anropa [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). För en bakgrund, använd [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), och för en fyllning, använd [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

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

Använd effektiva data för renderingsdiagnostik, validering och jämförelser. Om du bara inspekterar [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) kan du missa en master‑, layout‑, bild‑ eller form‑åsidosättning som förändrar det slutgiltiga utseendet.

## **FAQ**

**Påverkar tillämpning av ett externt tema varje bild i presentationen?**

Nej. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) omfördelar endast de bilder som beror på den valda mastern. Bilder som använder andra masters behåller sina befintliga teman.

**Kan jag tillämpa ett tema på en enskild bild utan att ändra master?**

Ja. Använd bildens [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) och initiera dess åsidosättnings‑tema. Ändringen förblir lokal för den bilden; övriga bilder fortsätter att ärva sina befintliga teman.

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**

När du flyttar en bild och bevarar dess källutseende, klona käll‑mastern till destinationen och klona bilden med den mastern via [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) och [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Detta behåller master, layouter och tema tillsammans.

**Hur kan jag se de effektiva värdena efter arv och åsidosättningar?**

Använd [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) för en bild‑ eller layout‑tema samt motsvarande effektiva‑datametoder för formatobjekt som [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) och [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Dessa API:er returnerar de lösta värdena efter att arv och åsidosättningar har tillämpats.