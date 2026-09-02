---
title: Spravujte témata PowerPoint prezentací v Pythonu
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
- další paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Hlavní témata prezentací v Aspose.Slides pro Python přes .NET k vytváření, přizpůsobení a převodu souborů PowerPoint s konzistentním brandováním."
---
## **Úvod**

Téma prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou „theme‑aware“, se místo pevně uložených vizuálních vlastností odkazuje na tato sdílená definice, takže změna tématu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je téma na úrovni prezentace dostupné prostřednictvím vlastnosti [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/). Prezentace může také obsahovat přepisy tématu na nižších úrovních. Master může přepsat téma prezentace pomocí [MasterThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/masterthememanager/override_theme/), rozvržení může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a jednotlivý snímek může udělat totéž. V praxi je efektivní téma pro snímek vyřešeno touto řetězovou dědičností: téma prezentace, přepis masteru, přepis rozvržení a přepis snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prozkoumat téma, změnit barvy a písma, kopírovat nebo použít téma, aktualizovat styly pozadí a efektů a číst efektivní hodnoty po vyřešení dědičnosti a přepisů.

## **Prozkoumání tématu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/) poskytuje přístup k vlastnostem [color_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/font_scheme/) a [format_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/format_scheme/). Prozkoumávání těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte master přiřazený k snímku a použijte pracovní postup s efektivním tématem uvedený později v tomto článku, když mohou být přítomny přepisy rozvržení nebo snímku.

## **Změna barev tématu**

Theme‑aware výplně, čáry a text mohou odkazovat na logickou barvu z výčtu [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) tématu, všechny objekty, které stále odkazují na tuto barvu tématu, jsou přepočítány na novou hodnotu. Objektům, které používají přímou RGB barvu, změna barvy tématu neovlivní.

Následující end‑to‑end příklad vytvoří tvar, který používá `ACCENT4`, změní barvu `accent4` tématu na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává spojený s `ACCENT4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `accent4` už tento výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlejší a tmavší barvy generované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy tématu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev tématu.

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `accent4` později změní, transformované barvy budou přepočítány z nové hodnoty `accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/) používá `TEXT1`, `BACKGROUND1`, `TEXT2` a `BACKGROUND2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) vystavuje stejné sloty tématu jako `dark1`, `light1`, `dark2` a `light2`. Mapování je pevně dané:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejsou to hodnoty, které by se dynamicky převáděly z jednoho tvaru do druhého.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Vlastnosti [FontScheme.major](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/major/) a [FontScheme.minor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/minor/) tyto sady vystavují.

Identifikátory písem kompatibilní s PowerPointem lze použít ve formátování textu:

* `+mn-lt` – tělo písmo Latin (Minor Latin Font)
* `+mj-lt` – nadpis písmo Latin (Major Latin Font)
* `+mn-ea` – tělo písmo East Asian (Minor East Asian Font)
* `+mj-ea` – nadpis písmo East Asian (Major East Asian Font)

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitní název písma namísto identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití tématu**

Existují dva běžné pracovní postupy a řeší různé problémy.

### **Zachování zdrojového tématu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní návrh, naklonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/), poté naklonujte snímek pomocí [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/) a klonovaného masteru. Tím se přenese master, jeho rozvržení a související téma společně.

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

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející master v cílové prezentaci může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Použití hodnot tématu na existujícím snímku**

Pokud cílový snímek musí zůstat na svém současném masteru a rozvržení, inicializujte úroveň snímku přepisem z tématu zdroje. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) zkopírují tři hlavní komponenty tématu do přepisu.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. Pro odstranění lokálního přepisu a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/clear/).

### **Použití přepisu tématu na rozvržení**

Přepis na úrovni rozvržení se aplikuje na snímky, které toto rozvržení používají, pokud nemá konkrétní snímek vlastní přepis. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte master nebo téma na úrovni prezentace, když má mnoho rozvržení a snímků sdílet stejný základní návrh, přepis rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepis snímku jen pro skutečné výjimky. Nadměrné přepisy na úrovni snímku ztěžují předvídání pozdějších globálních změn tématu.

## **Aktualizace stylů pozadí tématu**

Výplně pozadí tématu jsou uloženy v [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou kolekci a aktuální [Background.style_index](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/style_index/). `style_index` používá `0` pro žádnou tematickou výplň; kladné hodnoty jsou odkazy na styl pozadí tématu. To se liší od indexování Python kolekce přímo, kde `[0]` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše počet dostupných výplní pozadí, přiřadí odkaz na tematické pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na tématu, na které se odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte `style_index` jako nulový index kolekce. Také se vyhněte hardcodingu čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro konkrétní prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů tématu**

Formátovací schéma tématu obsahuje samostatné kolekce [FormatScheme.fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/line_styles/) a [FormatScheme.effect_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typické Office témata často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl každou kolekci prozkoumat místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když v Pythonu přistupujete k těmto kolekcím, index kolekce je nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy odkazů na styly tvaru jsou samostatným konceptem, vystaveným přes [IShapeStyle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapestyle/). Úprava stylu tématu ovlivní tvary, které tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad kontroluje, že požadované položky stylu existují, mění první styl čáry, mění třetí styl výplně, povoluje vnější stín ve třetím stylu efektu a ukládá výsledek:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí styl výplně tématu se stane plnou lesní zelenou a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každé těleso odkazuje, a zda přímé formátování nepřepisuje téma.

![Styly efektů tématu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot tématu**

Syrové objekty tématu vám říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty vám říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepisů. Pro snímek zavolejte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pro pozadí použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/), a pro výplň [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/).

Následující příklad načte efektivní téma, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prozkoumáte jen [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/), můžete přehlédnout přepis masteru, rozvržení, snímku nebo tvaru, který mění finální vzhled.

## **Často kladené otázky**

**Mohu použít téma na jeden snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepis tématu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí svá existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu naklonujte zdrojový master do cílové destinace a naklonujte snímek s tímto masterem pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/) a [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/). Tím se master, rozvržení a téma přenesou společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pro téma snímku nebo rozvržení a odpovídající metody pro efektivní data formátovacích objektů, jako jsou [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) a [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepisů.