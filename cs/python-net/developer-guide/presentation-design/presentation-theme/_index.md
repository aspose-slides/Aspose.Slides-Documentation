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
description: "Spravujte hlavní motivy prezentací v Aspose.Slides pro Python prostřednictvím .NET pro vytváření, přizpůsobování a konverzi souborů PowerPoint s konzistentním brandováním."
---
## **Úvod**

Prezentace má téma, které definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům vědomým motivu se odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může aktualizovat mnoho objektů najednou.

V Aspose.Slides je motiv na úrovni prezentace dostupný prostřednictvím vlastnosti [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace pomocí [MasterThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/masterthememanager/override_theme/), rozvržení může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a jednotlivý snímek může udělat to samé. V praxi je efektivní motiv pro snímek vyřešen řetězcem dědičnosti: motiv prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s motivem: prohlédnutí motivu, změna barev a písem, kopírování nebo aplikace motivu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/) vystavuje vlastnosti motivu [color_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/font_scheme/) a [format_scheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/mastertheme/format_scheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se může lišit.

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

Pokud soubor používá více masterů, nečekejte, že každý snímek má stejný efektivní motiv. Prohlédněte master přiřazený k snímku a použijte pracovní postup s efektivním motivem zobrazený dále v tomto článku, když mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Výplně, čáry a text, které jsou motivu vědomé, mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) motivu, všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyřešeny vůči nové hodnotě. Objekty, které používají přímou RGB barvu, nejsou aktualizovány při změně barvy motivu.

Následující end‑to‑end příklad vytvoří tvar, který používá `ACCENT4`, změní barvu motivu `accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává spojený s `ACCENT4`, jeho viditelná barva po změně motivu bude červená. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `accent4` už tento výplň neovlivní.

### **Použití barev z dodatkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barvy. Aspose.Slides zpřístupňuje tyto transformace přes výčtový typ [ColorTransformOperation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy generované z dodatkové palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `ACCENT4`, aplikuje na pět z nich luminanční transformace a výsledek uloží:

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

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `accent4` později změní, transformované barvy se přepočítají z nové hodnoty `accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčtový typ [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/) používá `TEXT1`, `BACKGROUND1`, `TEXT2` a `BACKGROUND2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/) vystavuje stejné sloty motivu jako `dark1`, `light1`, `dark2` a `light2`. Mapování je pevně dané:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty dynamicky převáděné z jedné podoby do druhé.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Vlastnosti [FontScheme.major](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/major/) a [FontScheme.minor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/fontscheme/minor/) tyto sady vystavují.

Identifikátory písem kompatibilní s PowerPointem lze použít při formátování textu:

* `+mn-lt` – Tělo písmo Latin (Minor Latin Font)
* `+mj-lt` – Nadpis písmo Latin (Major Latin Font)
* `+mn-ea` – Tělo písmo Východní Asie (Minor East Asian Font)
* `+mj-ea` – Nadpis písmo Východní Asie (Major East Asian Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo motivu, a jeden řádek těla, který používá vedlejší latinské písmo motivu. Poté změní písma motivu a výsledek uloží:

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

Nadpis používá hlavní písmo a tělo používá vedlejší písmo. Text, který má explicitně uvedený název písma místo identifikátoru motivu, se po změně schématu písem motivu automaticky nepřepne.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, např. cyriliku, arabštinu, japonštinu, gruzínštinu a thaana. Pro prohlédnutí, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentaci viz [PowerPoint Fonts](/slides/cs/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivem.

### **Aplikace externího motivu na snímky závislé na masteru**

Použijte [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/), když máte soubor motivu PowerPointu (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation.masters](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/masters/), která implementuje [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/), a předávejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master snímek na základě vybraného masteru.  
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

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxException](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pptxexception/) nebo jednu z jeho podtříd souvisejících s formátem. Ověřujte cesty dodané uživateli, ošetřete selhání přístupu k souborovému systému a uložte prezentaci až po úspěšné aplikaci motivu.

Pouze snímky, které závisely na vybraném masteru, jsou přeřazeny. Snímky spojené s jinými mastery si zachovají své stávající mastery a motivy. Barvy, písma, výplně, čáry, pozadí a efekty vědomé motivu jsou rozřešeny vůči externímu motivu. Přímo přiřazené barvy, písma, výplně a další explicitní formátování mohou zůstat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí k dispozici. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, zpřístupněte je přes [custom font sources](/slides/cs/python-net/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/python-net/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání motivu na úrovni snímku nebo rozvržení.

### **Aplikace různých externích motivů v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej z reprezentativního snímku pomocí [Slide.layout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/layout_slide/) a [LayoutSlide.master_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/master_slide/). Uložte původní odkazy na mastery před aplikací jakýchkoli motivů, protože každý volání vytvoří v prezentaci další master.

Následující příklad použije snímky ze dvou sekcí k nalezení jejich masterů a aplikuje na každou skupinu jiný externí motiv:

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

První volání ovlivní jen snímky, které závisely na `first_group_master`, a druhé volání ovlivní jen snímky, které závisely na `second_group_master`. Snímky patřící k jinému masteru nebudou přeformátovány.

### **Zachování zdrojového motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní návrh, klonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/), poté klonujte snímek pomocí [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/) a klonovaný master. Tím se přenese master, jeho rozvržení i přidružený motiv.

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

Jedná se o preferovaný pracovní postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikace hodnot motivu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv používaný tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplikace přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte motiv na úrovni masteru nebo prezentace, když mnoho rozvržení a snímků má sdílet stejný základní návrh, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišný styl, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint může ve svém uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background.style_index](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/style_index/). `style_index` používá `0` pro žádnou motivovou výplň; kladné hodnoty jsou reference na motivové styly pozadí. To se liší od indexování Pythonové kolekce, kde `[0]` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad vypíše počet dostupných výplní pozadí, přiřadí motivovou referenci na pozadí prvnímu masteru a uloží prezentaci:

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

Viditelný výsledek závisí na motivové položce, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek ovlivnit. Použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nevnímejte `style_index` jako nula‑založený index kolekce. Také se vyhýbejte tvrdému zakódování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátu motivu obsahuje oddělené kolekce [FormatScheme.fill_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/line_styles/) a [FormatScheme.effect_styles](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a výraznému formátování, ale kód by měl každou kolekci prozkoumat místo předpokladu pevného počtu.

![Jemné, střední a výrazné efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v Pythonu je index kolekce nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy referencí stylu tvaru jsou samostatný koncept, vystavený přes [IShapeStyle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapestyle/). Úprava motivového stylu ovlivní tvary, které na něj odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím efektovém stylu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první motivová čára stane červenou, třetí motivová výplň se stane plnou lesní zelení a třetí efekt získá vnější stín s odstupem 10 bodů. Přesný vizuální výsledek stále závisí na tom, který slot stylu každá forma odkazuje, a zda přímé formátování přepisuje motiv.

![Styly efektů motivu po změně čáry, výplně a stínu](presentation-design_11.png)

## **Určení, zda efektivní plná výplň používá barvu motivu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, motivového stylu či jiné úrovně formátování. Zavolejte [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/), aby se tato hierarchie vyřešila do neměnného [IFillFormatEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/). Nejprve zkontrolujte [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Pouze když je `FillType.SOLID`, čtěte vlastnosti plné výplně.

U plné výplně [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) vrací konečnou vykreslenou RGB hodnotu po dědičnosti, hledání motivu a aplikaci transformací barev. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/), např. `TEXT1` nebo `ACCENT6`. Hodnota `SchemeColor.NOT_DEFINED` znamená, že efektivní plná výplň není založena na schematické barvě. V pracovním postupu, kde jsou výplně buď motivové barvy nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nekládejte se jen na místní hodnotu [IColorFormat.scheme_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/icolorformat/scheme_color/). Například část textu může nemít lokálně definovanou schematickou barvu, takže její lokální hodnota je `NOT_DEFINED`, zatímco její efektivní výplň dědí motivovou barvu a resolve na `TEXT1` nebo `ACCENT6`. Naopak `solid_fill_scheme_color` vám říká, který logický slot motivu vytvořil efektivní barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozvržení, masteru nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, provede audit výplní tvarů i výplní částí textu, vytiskne každou finální RGB hodnotu a související schematickou barvu a označí plné výplně, které nebudou sledovat změny motivových barev:

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

Větve `NOT_DEFINED` poskytují auditní seznam plných výplní, které nebudou reagovat na změny slotů motivových barev. Prohlédněte si tyto objekty, když musí prezentace dodržovat novou paletu značky. Zprávěná RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled propojen s motivem.

Objekty efektivního formátu jsou snímky. Po změně motivu prezentace, přepsání motivu nebo jakéhokoli zděděného formátování znovu zavolejte `get_effective` a načtěte nový objekt `IFillFormatEffectiveData` před porovnáním nebo hlášením barev.

## **Čtení efektivních hodnot motivu**

Surové objekty motivu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pro pozadí použijte [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/), a pro výplň [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.master_theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/master_theme/), můžete přehlédnout přepsání na úrovni masteru, rozvržení, snímku či tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivňuje aplikace externího motivu všechny snímky v prezentaci?**

Ne. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) přeřadí jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovávají své stávající motivy.

**Mohu aplikovat motiv na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální k tomuto snímku; ostatní snímky nadále dědí své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu klonujte zdrojový master do cíle a klonujte snímek s tímto masterem pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/add_clone/) a [SlideCollection.add_clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/add_clone/). Tím se udrží master, rozvržení a motiv společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pro motiv snímku nebo rozvržení a odpovídající metody efektivních dat pro formátovací objekty, např. [Background.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/background/get_effective/) a [FillFormat.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/get_effective/). Tyto API vrátí rozřešené hodnoty po aplikaci dědičnosti a přepsání.