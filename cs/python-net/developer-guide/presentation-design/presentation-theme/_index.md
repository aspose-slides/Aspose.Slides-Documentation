---
title: Spravovat témata prezentací PowerPoint v Pythonu
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
- externí téma
- THMX
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
description: "Hlavní témata prezentací v Aspose.Slides pro Python přes .NET pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Prezentace téma definuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektů orientovaných na téma odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna tématu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je téma na úrovni prezentace k dispozici prostřednictvím vlastnosti [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). Prezentace může také obsahovat přepsání tématu na nižších úrovních. Hlavní snímek může přepsat téma prezentace pomocí [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), rozložení může přepsat své zděděné téma pomocí [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a jednotlivý snímek může udělat totéž. V praxi je efektivní téma pro snímek řešeno touto řetězovou dědičností: téma prezentace, přepsání hlavního snímku, přepsání rozložení a přepsání snímku.

![Komponenty tématu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s tématy: prozkoumat téma, měnit barvy a písma, kopírovat nebo použít téma, aktualizovat styly pozadí a efektů a číst efektivní hodnoty po vyřešení dědičnosti a přepsání.

## **Prozkoumat téma**

Objekt [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) vystavuje vlastnosti tématu [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) a [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/). Prozkoumání těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu může být různý.

Následující příklad načte hlavní vlastnosti tématu a nahlásí, kolik stylů pozadí, výplní, čar a efektů je uloženo v tématu:

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

Pokud soubor používá více hlav, nepředpokládejte, že každý snímek má stejné efektivní téma. Prozkoumejte hlavní snímek přiřazený k snímkům a použijte pracovní postup s efektivním tématem uvedený později v článku, když mohou být přítomna přepsání rozložení nebo snímku.

## **Změna barev tématu**

Vyplněné objekty, čáry a text orientované na téma mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/), všechny objekty, které stále odkazují na tuto barvu tématu, jsou vyřešeny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna barvy tématu neprojeví.

Následující end‑to‑end příklad vytvoří tvar, který používá `ACCENT4`, změní barvu tématu `accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstane propojen s `ACCENT4`, jeho viditelná barva se po změně tématu stane červenou. Pokud nahradíte barvu schématu přímou barvou na tvaru, pozdější změny `accent4` už tento výplň neovlivní.

### **Použít barvy z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy tématu pomocí transformací barev. Aspose.Slides tuto funkcionalitu vystavuje prostřednictvím výčtu [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Hlavní barvy tématu a světlé a tmavé barvy generované z doplňkové palety](additional-palette-colors.png)

**1** - Hlavní barvy tématu.

**2** - Světlé a tmavé varianty vytvořené z hlavních barev tématu.

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

Tyto varianty zůstávají založeny na barvě tématu. Pokud se `accent4` později změní, transformované barvy se přepočítají z nové hodnoty `accent4`.

### **Mapovat hodnoty `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) používá `TEXT1`, `BACKGROUND1`, `TEXT2` a `BACKGROUND2`, zatímco [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) vystavuje stejné sloty tématu jako `dark1`, `light1`, `dark2` a `light2`. Mapování je pevné:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Jedná se o alternativní názvy pro stejné sloty tématu; nejedná se o hodnoty dynamicky převáděné z jedné formy do druhé.

## **Změna písem tématu**

Schéma písem tématu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Vlastnosti [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) a [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) tyto sady vystavují.

Identifikátory písem kompatibilní s PowerPointem lze použít při formátování textu:

* `+mn-lt` – Body Font Latin (menší Latin písmo)
* `+mj-lt` – Heading Font Latin (větší Latin písmo)
* `+mn-ea` – Body Font East Asian (menší východoasijské písmo)
* `+mj-ea` – Heading Font East Asian (větší východoasijské písmo)
* `+mn-cs` – Body Font Complex Script (menší písmo složitých skriptů)
* `+mj-cs` – Heading Font Complex Script (větší písmo složitých skriptů)

Následující příklad vytvoří jeden nadpis, který používá hlavní Latin písmo tématu, a jeden řádek těla, který používá menší Latin písmo tématu. Poté změní písma tématu a výsledek uloží:

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

Nadpis používá hlavní písmo a text těla používá menší písmo. Text, který má explicitní název písma místo identifikátoru tématu, se automaticky nepřepne, když se změní schéma písem tématu.

Hlavní a vedlejší sbírky písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prozkoumání, přidání, nahrazení nebo odebrání těchto mapování viz [Script-Specific Theme Fonts](/slides/cs/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písmenech v prezentaci viz [PowerPoint Fonts](/slides/cs/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Vyřešit odkazy na písmo tématu**

Při prohlížení textu může [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) obsahovat odkaz na téma, jako je `+mn-lt`, místo názvu rodiny písma. Zavolejte [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) s příslušným [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/), aby se odkaz vyřešil. Předpony `+mj` a `+mn` vybírají hlavní a vedlejší sadu písem; přípony `-lt`, `-ea` a `-cs` vybírají jejich Latin, East Asian a Complex Script písma.

Získejte efektivní téma pomocí [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) na objektu, jehož téma se vztahuje k prohlíženému textu. Pro běžný text na snímku použijte `slide.create_theme_effective`, aby kontext zahrnoval zděděné téma snímku a lokální přepsání. Při prohlížení rozložení nebo hlavního snímku použijte jeho vlastní efektivní téma. Nepředpokládejte, že téma prvního hlavního snímku platí pro každý snímek.

Následující příklad vytvoří část textu, která explicitně odkazuje na menší Latin písmo. Inicializuje schéma písem snímku pomocí [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) a nastaví hlavní a vedlejší Latin rodiny na `Arial` a `Calibri`, čímž je výsledek reprodukovatelný bez vstupního souboru.

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

Výstup je `+mn-lt -> Calibri` následovaný `Verdana -> Verdana`. Uchovaná reference zůstává beze změny, zatímco explicitní název rodiny je vrácen tak, jak je. Kdyby část použila `+mj-lt`, vyřešila by se na `Arial` v tomto tématu.

Vyřešení odkazu na téma identifikuje rodinu písma určenou tématem. Nekontroluje dostupnost písma ani neurčuje soubor písma, který je nakonec použit po substituci nebo fallbacku během vykreslování. Viz [Font Selection Sequence](/slides/cs/python-net/font-selection-sequence/) a [Font Substitution](/slides/cs/python-net/font-substitution/) pro tyto samostatné kroky.

## **Kopírovat nebo použít téma**

Níže uvedené pracovní postupy řeší různé problémy související s tématy.

### **Použít externí téma na snímky závislé na hlavním snímku**

Použijte [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/), když máte soubor tématu PowerPoint (`.thmx`) a chcete přestylovat každý snímek, který závisí na konkrétním hlavním snímku. Vyberte hlavní snímek ze sbírky [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) a předávejte cestu k souboru tématu metodě.

Metoda provádí následující operace:

1. Vytvoří nový hlavní snímek založený na vybraném hlavním snímku.
1. Aplikuje externí téma na nový hlavní snímek.
1. Přiřadí nový hlavní snímek všem snímkům, které dosud závisely na vybraném hlavním snímku.
1. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

Následující příklad aplikuje externí téma na snímky, které závisí na prvním hlavním snímku, a uloží prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Neplatné, poškozené nebo nepodporované téma může vyvolat [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) nebo některou z jejich podtříd souvisejících s formátem. Ověřte cesty zadávané uživateli, ošetřete selhání přístupu k systému souborů a uložte prezentaci až po úspěšném použití tématu.

Přesouvají se jen snímky, které závisely na vybraném hlavním snímku. Snímek přiřazený k jiným hlavním snímkům si zachová své existující hlavní snímky a témata. Barvy, písma, výplně, čáry, pozadí a efekty orientované na téma jsou vyřešeny vůči externímu tématu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami zděděnými z nového hlavního snímku.

Téma může odkazovat na písma, která nejsou v běhovém prostředí dostupná. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytněte je prostřednictvím [custom font sources](/slides/cs/python-net/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/python-net/font-substitution/).

Jedná se o přímý pracovní postup na úrovni hlavního snímku: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání tématu na úrovni snímku nebo rozložení.

### **Použít různá externí témata ve prezentaci s více hlavami**

Když není hlavní snímek znám předem, získejte jej z reprezentativního snímku pomocí [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) a [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Uchovejte původní odkazy na hlavní snímky před aplikací jakýchkoli témat, protože každý volání vytvoří další hlavní snímek v prezentaci.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich hlavních snímků a aplikuje jiná externí témata na každou skupinu:

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

První volání ovlivní jen snímky, které závisely na `first_group_master`, a druhé volání ovlivní jen snímky, které závisely na `second_group_master`. Snímky patřící k nějakému jinému hlavnímu snímku nebudou přestylovány.

### **Zachovat zdrojové téma při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový hlavní snímek do cílové prezentace pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), poté klonujte snímek pomocí [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) a klonovaného hlavního snímku. Tím se přenese hlavní snímek, jeho rozložení i související téma.

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

Toto je preferovaný pracovní postup, když musí zdrojový snímek v cílovém souboru vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový hlavní snímek může změnit barvy, písma, pozadí a efekty řízené tématem.

### **Použít hodnoty tématu na existující snímek**

Pokud musí cílový snímek zůstat na svém aktuálním hlavním snímku a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového tématu. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) a [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) zkopírují tři hlavní komponenty tématu do přepsání.

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

Tím se změní téma použité tímto snímkem, aniž by se změnilo téma zděděné ostatními snímky. K odebrání lokálního přepsání a návratu k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **Použít přepsání tématu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají toto rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Použijte téma na úrovni hlavního snímku nebo prezentace, když mnoho rozložení a snímků má sdílet stejný základní design, přepsání rozložení, když jedna rodina rozložení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Přehnané přepsání na úrovni snímku ztěžuje předpověď následných globálních změn tématu.

## **Aktualizovat style pozadí tématu**

Barvy pozadí tématu jsou uloženy v [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint může ve svém uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně tématu s barvami tématu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro téma prezentace](presentation-design_8.png)

Před použitím stylu pozadí prozkoumejte uloženou kolekci a aktuální [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` používá `0` pro žádnou tematickou výplň; kladné hodnoty jsou odkazy na tematické styly pozadí. To se liší od indexování Python kolekce přímo, kde `[0]` znamená první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí dostupný počet výplní pozadí, přiřadí tematický odkaz na pozadí prvnímu hlavnímu snímku a uloží prezentaci:

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

Viditelný výsledek závisí na položce tématu, na kterou odkazuje hlavní snímek, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna jen pozadí hlavního snímku nemusí tento snímek změnit. Použijte [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nepojetí `style_index` jako nulového indexu kolekce. Také se vyhněte tvrdému kódování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů tématu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizovat efekty tématu**

Schéma formátu tématu obsahuje samostatné kolekce [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) a [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typické Office téma často obsahuje tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou kolekci místo předpokládání pevného počtu.

![Jemné, střední a intenzivní efekty tématu aplikované na stejný tvar](presentation-design_10.png)

Když v Pythonu přistupujete k těmto kolekcím, index kolekce je nulový: `[0]` je první uložený styl a `[2]` je třetí. Indexy stylových odkazů tvaru jsou samostatný koncept, vystavený přes [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Změna stylu tématu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které odkazují na tyto sloty, se první styl čáry tématu stane červeným, třetí výplň tématu se změní na plnou lesní zelenou a třetí efekt získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, na které sloty každý tvar odkazuje a zda přímé formátování nepřepíše téma.

![Efekty tématu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Vybrat výplň a styly čar tématu pro tvar**

Tvar může nezávisle vybrat svou výplň a obrys přes [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) a [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). Pro obě vlastnosti index `1` vybírá první položku v příslušné kolekci tématu (`fill_styles[0]` nebo `line_styles[0]`) a index `2` vybírá druhou položku.

Následující příklad definuje dvě výplně (zlatá a nebeská modř) a dva obrysy (tmavě modrá 6 pt a tmavě červená 12 pt) v výchozím tématu nové prezentace. Uloží snímek ve třech fázích, abyste mohli porovnat výsledky v PowerPointu.

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

| Počáteční styly | Změnit pravý obrys | Upravit první výplň tématu |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Výběr jiného stylu čáry mění pouze obrys pravého obdélníku. Úprava první výplně tématu aktualizuje každý tvar, který ji používá. Zde se pouze levý obdélník zbarví zeleně.

Na existujícím tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat tuto část stylu tématu. Pokud změna indexu stylu nemá viditelný efekt, zkontrolujte [direct formatting](/slides/cs/python-net/shape-formatting/).

## **Zjistit, zda efektivní plná výplň používá barvu tématu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozložení, hlavního snímku, stylu tématu nebo jiné úrovně formátování. Zavolejte [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) k vyřešení této hierarchie na neměnná [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/). Nejprve ověřte [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Pouze když je `FillType.SOLID`, čtěte vlastnosti pevné výplně.

Pro pevnou výplň vrací [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) konečnou vykreslenou RGB hodnotu po dědičnosti, vyhledání v tématu a aplikaci transformací barev. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/), např. `TEXT1` nebo `ACCENT6`. Hodnota `SchemeColor.NOT_DEFINED` znamená, že efektivní pevná výplň není založena na schématu barvy. V pracovním postupu, kde jsou výplně buď barvy tématu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

 Nepoužívejte lokální hodnotu [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) samostatně pro klasifikaci výplně. Například část textu může nemít lokálně definovanou barvu schématu, takže její lokální hodnota je `NOT_DEFINED`, zatímco její efektivní výplň zdědí barvu tématu a vyřeší se na `TEXT1` nebo `ACCENT6`. Naopak `solid_fill_scheme_color` vám řekne, který logický slot tématu vytvořil efektivní barvu, ale neřekne, zda tento slot pochází z objektu, odstavce, rozložení, hlavního snímku nebo jiné úrovně hierarchie formátování.

Následující příklad načte prezentaci, zkontroluje výplně tvarů i výplně částí textu, vytiskne každou finální RGB hodnotu a související barvu schématu a označí pevné výplně, které nebudou sledovat změny barev tématu:

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

Větev `NOT_DEFINED` poskytuje auditní seznam pevné výplně, která nebude reagovat na změny v slotách barev tématu. Prohlédněte si tyto objekty, když musí prezentace následovat novou paletu značky. Nahlášená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled propojen s tématem.

Objekty efektivního formátu jsou snímky v čase. Po změně tématu prezentace, přepsání tématu nebo libovolného zděděného formátování zavolejte `get_effective` znovu a načtěte nový objekt `IFillFormatEffectiveData`, než budete porovnávat nebo hlásit barvy.

## **Číst efektivní hodnoty tématu**

Surové objekty tématu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pro pozadí použijte [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), a pro výplň [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/), můžete přehlédnout hlavní, rozložení, snímek nebo přepsání tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Má aplikace externího tématu vliv na každý snímek v prezentaci?**

Ne. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) přidělí pouze snímky, které závisí na vybraném hlavním snímku. Snímky používající jiné hlavní snímky si zachovají svá existující témata.

**Mohu použít téma na jediný snímek bez změny hlavního snímku?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) snímku a inicializujte jeho přepsání tématu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále dědit svá existující témata.

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový hlavní snímek do cílové prezentace a klonujte snímek s tímto hlavním snímkem pomocí [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) a [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Tím se zachová hlavní snímek, rozložení i téma.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pro téma snímku nebo rozložení a odpovídající metody efektivního dat pro formátové objekty, jako jsou [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) a [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Tyto API vracejí vyřešené hodnoty po aplikaci dědičnosti a přepsání.