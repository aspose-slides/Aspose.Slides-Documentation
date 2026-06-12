---
title: Správa témat prezentací PowerPoint v Pythonu
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
- doplňková paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte témata prezentací v Aspose.Slides pro Python pomocí .NET k vytváření, úpravě a konverzi souborů PowerPoint s jednotnou vizuální identitou."
---
## **Úvod**

Téma prezentace definuje vlastnosti jejích návrhových prvků. Když vyberete téma, volíte koordinovanou sadu vizuálních prvků a jejich vlastností.

V PowerPointu téma zahrnuje barvy, [písma](/slides/cs/python-net/powerpoint-fonts/), [styly pozadí](/slides/cs/python-net/presentation-background/), a efekty.

![prvky tématu](theme-constituents.png)

## **Změna barvy tématu**

Téma PowerPointu používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám výchozí barvy nelíbí, můžete je změnit aplikací nových barev tématu. Aby vám umožnilo vybrat novou barvu tématu, Aspose.Slides poskytuje hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/).

Tento Python kód ukazuje, jak změnit akcentní barvu tématu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Můžete určit efektivní hodnotu výsledné barvy následujícím způsobem:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Výstup příkladu:
#
# ff8064a2 (Barva [A=255, R=128, G=100, B=162])
```

Abychom dále demonstrovali změnu barvy, vytvoříme další prvek, přiřadíme mu akcentní barvu z úvodního kroku a poté aktualizujeme barvu tématu.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Nová barva je automaticky použita na oba prvky.

### **Nastavení barvy tématu z doplňkové palety**

Když použijete transformace jasu na hlavní barvu tématu (1), jsou generovány barvy z doplňkové palety (2). Poté můžete tyto barvy tématu nastavit a získat.

![barvy doplňkové palety](additional-palette-colors.png)

**1** — Hlavní barvy tématu  
**2** — Barvy z doplňkové palety

Tento Python kód demonstruje, jak jsou barvy doplňkové palety odvozeny z hlavní barvy tématu a následně použity ve tvarech:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Akcent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Akcent 4, světlejší 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Akcent 4, světlejší 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Akcent 4, světlejší 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Akcent 4, tmavší 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Akcent 4, tmavší 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Mapování `SchemeColor` na barvy `ColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/python-net/aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barev tématu:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` a `TEXT2`.

Nicméně `Presentation.master_theme.color_scheme` vrací [ColorScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/colorscheme/), který zpřístupňuje odpovídající barvy jako:

`dark1`, `dark2`, `light1` a `light2`.

Tento rozdíl je pouze v názvosloví. Tyto hodnoty odkazují na stejné sloty barev tématu a mapování je pevné:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Neexistuje žádná dynamická konverze mezi `TEXT`/`BACKGROUND` a `dark`/`light`. Jedná se pouze o alternativní názvy stejných barev tématu.

Tento rozdíl v názvosloví pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější verze UI zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma tématu**

Aby vám umožnilo vybrat písma pro témata a další účely, Aspose.Slides používá tyto speciální identifikátory (podobné těm v PowerPointu):

- **+mn-lt** — Tělo písmo Latin (Minor Latin Font)
- **+mj-lt** — Titulní písmo Latin (Major Latin Font)
- **+mn-ea** — Tělo písmo East Asian (Minor East Asian Font)
- **+mj-ea** — Titulní písmo East Asian (Major East Asian Font)

Tento Python kód ukazuje, jak přiřadit latinské písmo k prvku tématu:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Tento Python příklad ukazuje, jak změnit písmo tématu prezentace:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Všechny textové rámečky budou aktualizovány na nové písmo.

{{% alert color="primary" title="TIP" %}}
Pro více informací viz [Hlavní písma PowerPointu s Pythonem](/slides/cs/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí tématu**

Ve výchozím nastavení PowerPoint poskytuje 12 předdefinovaných pozadí, ale typická prezentace ukládá jen 3 z nich.

![předdefinovaná pozadí](presentation-design_8.png)

Například po uložení prezentace v PowerPointu můžete spustit následující Python kód, abyste zjistili, kolik předdefinovaných pozadí obsahuje:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Pomocí vlastnosti `background_fill_styles` ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/) můžete přidat nebo získat styly pozadí v tématu PowerPointu.
{{% /alert %}}

Tento Python příklad ukazuje, jak nastavit pozadí prezentace:

```python
presentation.masters[0].background.style_index = 2  # 0 označuje žádnou výplň; indexování začíná od 1.
```

{{% alert color="primary" title="TIP" %}}
Pro více informací viz [Správa pozadí prezentací v Pythonu](/slides/cs/python-net/presentation-background/).
{{% /alert %}}

## **Změna efektů tématu**

Téma PowerPointu typicky obsahuje tři hodnoty v každém poli stylů. Tato pole se kombinují do tří úrovní efektů: jemný, střední a intenzivní. Například zde je výsledek, když jsou tyto efekty aplikovány na konkrétní tvar:

![aplikované efekty](presentation-design_10.png)

Použitím tří vlastností — `FillStyles`, `LineStyles` a `EffectStyles` — ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/formatscheme/) můžete upravit prvky tématu (ještě flexibilněji než v PowerPointu).

Tento Python kód ukazuje, jak změnit efekt tématu úpravou částí těchto prvků:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Výsledné změny zahrnují aktualizace barvy výplně, typu výplně, stínového efektu a dalších vlastností:

![výsledky změn](presentation-design_11.png)

## **Často kladené otázky**

**Mohu použít téma na jediný snímek, aniž bych změnil master?**

Ano. Aspose.Slides podporuje přepsání tématu na úrovni snímku, takže můžete použít lokální téma jen na tento snímek a zároveň zachovat hlavní téma nedotčené (prostřednictvím [SlideThemeManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/slidethememanager/)).

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

[Klonovat snímky](/slides/cs/python-net/clone-slides/) spolu s jejich masterem do cílové prezentace. Toto zachová originální master, rozvržení a související téma, takže vzhled zůstane konzistentní.

**Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědění a přepsání?**

Použijte „efektivní“ pohledy API (["effective" views](/slides/cs/python-net/shape-effective-properties/)) pro téma/barvu/písmo/efekt. Tyto vrací vyřešené konečné vlastnosti po aplikaci masteru a všech lokálních přepisů.