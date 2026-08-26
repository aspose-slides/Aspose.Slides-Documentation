---
title: Spravujte motivy PowerPoint prezentací v Pythonu
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/python-net/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Externí motiv
- THMX
- Barva motivu
- Doplňková paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Ovládejte motivy prezentací v Aspose.Slides pro Python přes .NET pro vytváření, přizpůsobení a konverzi souborů PowerPoint s konzistentním brandováním."
---
## **Úvod**

Prezentační motiv definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům citlivým na motiv se odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je motiv na úrovni prezentace dostupný prostřednictvím vlastnosti [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace pomocí [MasterThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/masterthememanager/override_theme/), rozvržení může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a jednotlivý snímek může udělat totéž. V praxi se efektivní motiv pro snímek řeší touto řetězovou dědičností: motiv prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější postupy práce s motivem: prozkoumat motiv, měnit barvy a písma, kopírovat nebo aplikovat motiv, aktualizovat styly pozadí a efektů a číst efektivní hodnoty po vyřešení dědičnosti a přepsání.

## **Prozkoumání motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/) zveřejňuje vlastnosti motivu [color_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/font_scheme/), a [format_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/format_scheme/). Prozkoumání těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prozkoumejte master přiřazený ke snímku a použijte postup efektivního motivu uvedený později v tomto článku, pokud mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Výplně, čáry a text citlivé na motiv mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/). Když změníte odpovídající položku v motivu [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou rozšířeny na novou hodnotu. Objekty, které používají přímou barvu RGB, nejsou změněny aktualizací barvy motivu.

Následující komplexní příklad vytvoří tvar, který používá `ACCENT4`, změní barvu motivu `accent4` na červenou, uloží prezentaci, znovu ji otevře a vypíše efektivní barvu výplně:

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

Protože obdélník zůstává propojen s `ACCENT4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu ze schématu přímou barvou na tvaru, pozdější změny `accent4` již tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu pomocí transformací barev. Aspose.Slides tyto transformace zpřístupňuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** - Hlavní barvy motivu.

**2** - Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `ACCENT4`, aplikuje na pět z nich luminanční transformace a uloží výsledek:

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

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `accent4` později změní, transformované barvy jsou přepočítány z nové hodnoty `accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/) používá `TEXT1`, `BACKGROUND1`, `TEXT2` a `BACKGROUND2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) zveřejňuje stejné sloty motivu jako `dark1`, `light1`, `dark2` a `light2`. Mapování je pevné:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Toto jsou alternativní názvy pro stejné sloty motivu; nejedná se o hodnoty, které jsou dynamicky převáděny z jedné formy do druhé.

## **Změna písem motivu**

Sada písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Vlastnosti [FontScheme.major](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/major/) a [FontScheme.minor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/minor/) tuto sadu zveřejňují.

Identifikátory písem kompatibilní s PowerPointem lze použít při formátování textu:

* `+mn-lt` – tělesné písmo Latin (Minor Latin Font)
* `+mj-lt` – nadpisové písmo Latin (Major Latin Font)
* `+mn-ea` – tělesné písmo East Asian (Minor East Asian Font)
* `+mj-ea` – nadpisové písmo East Asian (Major East Asian Font)

Následující příklad vytvoří nadpis používající hlavní latinské písmo motivu a řádek těla používající vedlejší latinské písmo motivu. Poté změní písma motivu a uloží výsledek:

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

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitní název písma místo identifikátoru motivu, se automaticky nepřepne při změně sady písem motivu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo aplikace motivu**

Následující postupy řeší různé problémy související s motivem.

### **Aplikace externího motivu na snímky závislé na masteru**

Použijte [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) když máte soubor motivu PowerPoint (`.thmx`) a chcete přestylovat každý snímek, který závisí na konkrétním masteru. Vyberte master z kolekce [Presentation.masters](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/masters/), která implementuje [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/), a předávejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master slide založený na vybraném masteru.
1. Aplikuje externí motiv na nový master.
1. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.
1. Vrátí nově vytvořený [IMasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterslide/).

Následující příklad aplikuje externí motiv na snímky, které závisí na prvním masteru, a uloží prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Neplatný, poškozený nebo nepodporovaný motiv může způsobit [PptxException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxexception/) nebo některou z jejích podtříd souvisejících s formátem. Ověřte cesty poskytnuté uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšném použití motivu.

Pouze snímky, které závisely na vybraném masteru, jsou přeřazeny. Snímky spojené s ostatními mastery si zachovávají své stávající mastery a motivy. Barvy, písma, výplně, čáry, pozadí a efekty citlivé na motiv jsou rozšířeny vůči externímu motivu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými od nového masteru.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytujte je prostřednictvím [custom font sources](/slides/cs/python-net/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/python-net/font-substitution/).

Toto je přímý postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání motivu na úrovni snímku nebo rozvržení.

### **Aplikace různých externích motivů ve vícemoztrové prezentaci**

Pokud není relevantní master předem znám, získejte jej z reprezentativního snímku pomocí [Slide.layout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/layout_slide/) a [LayoutSlide.master_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/master_slide/). Uložte původní reference masterů před aplikací jakýchkoli motivů, protože každé volání vytvoří další master v prezentaci.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich masterů a aplikuje odlišný externí motiv na každou skupinu:

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

První volání ovlivní pouze snímky, které závisely na `first_group_master`, a druhé volání ovlivní pouze snímky, které závisely na `second_group_master`. Snímky patřící k jinému masteru nebudou přeformátovány.

### **Zachování zdrojového motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní vzhled, klonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/), potom klonujte snímek pomocí [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/) a klonovaného masteru. Tím se přenese master, jeho rozvržení a související motiv společně.

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

Toto je preferovaný postup, když musí snímek ve zdroji vypadat stejně v cíli. Pouhé klonování obsahu na nesouvisející master v cíli může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikace hodnot motivu na existující snímek**

Pokud má cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv použitý tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplikace přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky používající toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/layoutslidethememanager/) rozvržení:

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

Použijte motiv na úrovni masteru nebo prezentace, když mnoho rozvržení a snímků má sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku pouze pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou kolekci a aktuální [Background.style_index](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/style_index/). `style_index` používá `0` pro žádnou výplň motivu; kladné hodnoty jsou reference na styl pozadí motivu. To se liší od indexování kolekce v Pythonu přímo, kde `[0]` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejné množství stylů výplní pozadí.

Následující příklad vypíše dostupný počet výplní pozadí, přiřadí referenci motivu pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na položce motivu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Upozornění" %}}
Nepovažujte `style_index` za nulový index kolekce. Také se vyhněte pevně kódovanému číslu stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Sada formátů motivu obsahuje samostatné kolekce [FormatScheme.fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/line_styles/), a [FormatScheme.effect_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typické motivy Office často obsahují tři hlavní položky stylů, které vizuálně odpovídají náznakovým, středním a intenzivním formátování, ale kód by měl procházet každou kolekci místo předpokladu pevného počtu.

![Náznakové, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když přistupujete k těmto kolekcím v Pythonu, index kolekce je nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy referencí stylu tvaru jsou samostatný koncept, zveřejněný prostřednictvím [IShapeStyle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapestyle/). Modifikace stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

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

U tvarů, které odkazují na tyto sloty, se první styl čáry motivu změní na červený, třetí styl výplně motivu na plnou lesní zelenou a třetí styl efektu získá vnější stín vzdálený 10 bodů. Přesný vizuální výsledek stále závisí na tom, na které sloty stylu každý tvar odkazuje a zda přímé formátování přepisuje motiv.

![Styly efektů motivu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot motivu**

Surové objekty motivu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty ukazují, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pro pozadí použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/), a pro výplň použijte [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prozkoumáte jen [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/), můžete přehlédnout master, rozvržení, snímek nebo přepsání tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivní aplikace externího motivu každý snímek v prezentaci?**

Ne. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) přeassignuje pouze snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovávají své existující motivy.

**Mohu aplikovat motiv na jednotlivý snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále zdědit své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cíle a klonujte snímek s tímto masterem pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/) a [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/). Tím se master, rozvržení a motiv zachovají spolu.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pro motiv snímku nebo rozvržení a odpovídající metody efektivních dat pro formátové objekty, jako jsou [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) a [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.