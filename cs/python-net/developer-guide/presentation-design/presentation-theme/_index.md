---
title: Správa témat PowerPoint prezentací v Pythonu
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/python-net/presentation-theme/
keywords:
- Téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- barva tématu
- doplněná paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro Python pomocí .NET k vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Téma prezentace definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objekty pracující s tématem odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma úrovně prezentace k dispozici prostřednictvím vlastnosti [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/masterthememanager/override_theme/), layout může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a jednotlivý snímek může udělat totéž. V praxi je efektivní téma pro snímek získáno přes tento řetězec dědičnosti: téma prezentace, přepsání masteru, přepsání layoutu a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejběžnější pracovní postupy s tématem: prozkoumání tématu, změna barev a písem, kopírování nebo aplikace tématu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepisů.

## **Prozkoumání tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/) vystavuje vlastnosti tématu [color_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/font_scheme/) a [format_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/format_scheme/). Prohlížení těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

Následující příklad načte hlavní vlastnosti tématu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v tématu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte master přiřazený ke snímku a použijte pracovní postup s efektivním tématem uvedený později v tomto článku, pokud mohou být přítomna přepsání layoutu nebo snímku.

## **Změna barev tématu**

Objekty pracující s tématem (výplně, čáry a text) mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) tématu, všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyřešeny vůči nové hodnotě. Objekty používající přímou RGB barvu nejsou změněny aktualizací barvy tématu.

Následující kompletní příklad vytvoří tvar používající `ACCENT4`, změní barvu `accent4` tématu na červenou, uloží prezentaci, znovu ji otevře a vypíše efektivní barvu výplně:

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

Protože obdélník zůstává spojen s `ACCENT4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `accent4` už tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** - Hlavní barvy tématu.  
**2** - Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

Následující příklad vytvoří šest obdélníků založených na `ACCENT4`, aplikuje na pět z nich transformace jasu a uloží výsledek:

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `accent4` později změní, transformované barvy jsou přepočítány z nové hodnoty `accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/) používá `TEXT1`, `BACKGROUND1`, `TEXT2` a `BACKGROUND2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) vystavuje stejné sloty tématu jako `dark1`, `light1`, `dark2` a `light2`. Mapování je pevné:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty dynamicky převáděné z jednoho formátu do druhého.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Vlastnosti [FontScheme.major](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/major/) a [FontScheme.minor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/minor/) vystavují tyto sady.

PowerPoint‑kompatibilní identifikátory písem tématu lze použít při formátování textu:

* `+mn‑lt` – Písmo těla Latin (Minor Latin Font)
* `+mj‑lt` – Písmo nadpisu Latin (Major Latin Font)
* `+mn‑ea` – Písmo těla East Asian (Minor East Asian Font)
* `+mj‑ea` – Písmo nadpisu East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo tématu a jeden řádek těla používající vedlejší latinské písmo tématu. Poté změní písma tématu a uloží výsledek:

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

Nadpis používá hlavní písmo a tělo textu používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

{{% alert color="info" title="Tip" %}}
Pro více informací o písmech v prezentaci si přečtěte [PowerPoint Fonts](/slides/cs/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo aplikace tématu**

Existují dva běžné pracovní postupy a řeší různé problémy.

### **Zachování zdrojového tématu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní návrh, naklonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/), poté naklonujte snímek pomocí [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/) a naklonovaného masteru. Tím se přenese master, jeho rozvržení a související téma spolu.

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

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející master cíle může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Aplikace hodnot tématu na existující snímek**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a layoutu, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplikace přepsání tématu na rozvržení**

Přepsání na úrovni layoutu se použije na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte master nebo téma na úrovni prezentace, když má mnoho layoutů a snímků sdílet stejný základní návrh, přepsání layoutu, když jedna rodina layoutů potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint může v UI nabídnout více možností pozadí než je počet fyzicky uložených definic výplní v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.style_index](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/style_index/). `style_index` používá `0` pro žádnou výplň z tématu; kladné hodnoty jsou odkazy na styly pozadí tématu. To se liší od indexování Python kolekce přímo, kde `[0]` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni layoutu nebo snímku. Pokud snímek používá vlastní pozadí, změna jen pozadí masteru nemusí tento snímek změnit. Použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nepořádejte `style_index` jako nulový index kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí si prostudujte [Presentation Background](/slides/cs/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Schéma formátování tématu obsahuje samostatné kolekce [FormatScheme.fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/line_styles/) a [FormatScheme.effect_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typická office témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl každou kolekci prozkoumat místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když v Pythonu přistupujete k těmto kolekcím, index kolekce je nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy odkazů na styl tvaru jsou samostatný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane pevnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar odkazuje a zda přímé formátování přepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot tématu**

Surová témata vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pro pozadí použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/), a pro výplň [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prozkoumáte jen [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/), můžete přehlédnout přepsání masteru, layoutu, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Mohu aplikovat téma na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cíle a naklonujte snímek s tímto masterem pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/) a [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/). Tím se master, rozvržení a téma udrží pohromadě.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pro téma snímku nebo layoutu a odpovídající metody efektivních dat pro formátovací objekty, jako jsou [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) a [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/). Tyto API vrátí vyřešené hodnoty po aplikaci dědičnosti a přepsání.