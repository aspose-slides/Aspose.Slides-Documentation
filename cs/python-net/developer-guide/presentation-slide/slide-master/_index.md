---
title: Správa slide masterů v Pythonu
linktitle: Slide master
type: docs
weight: 80
url: /cs/python-net/slide-master/
keywords:
- master snímku
- master snímek
- PPT master snímek
- více master snímků
- porovnání master snímků
- pozadí
- zástupný objekt
- klonovat master snímek
- kopírovat master snímek
- duplikovat master snímek
- nepoužívaný master snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte slide mastery v Aspose.Slides for Python via .NET: přístup, úpravy, klonování, porovnání a odstraňování master snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**Slide master** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for Python via .NET podporuje stejný model. Prezentace může obsahovat jeden nebo více master slidů a každý master slide může obsahovat několik layout slidů. Normální snímky se obvykle nepřímo neodkazují na master slide. Místo toho normální snímek používá layout slide, který patří k master slide.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.  
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni rozvržení.  
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout slide.

![Hierarchie master slidů, layout slidů a normálních slidů](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) . Všechny master slidy v prezentaci jsou dostupné prostřednictvím kolekce `Presentation.masters`.

{{% alert color="info" title="Dědičnost" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud master slide a layout slide oba definují pozadí, snímky založené na tomto rozvržení použijí pozadí rozvržení. Další informace o layout slidech naleznete v [Apply or Change Slide Layouts](/slides/cs/python-net/slide-layout/).
{{% /alert %}}

## **Přístup k slide masterům**

V PowerPointu můžete otevřít zobrazení Slide Master z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `masters` k přístupu k master slideům:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Můžete také získat master slide použitý normálním snímkem prostřednictvím jeho rozvržení:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Co obsahuje slide master**

Master slide je objekt podobný snímku. Dědí společné chování snímku ze třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/) , takže poskytuje mnoho stejných vlastností snímků, které se používají u normálních a layout slidů. Členy specifické pro master jsou uvedeny na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) .

Běžně používané členy master slide zahrnují:

| Člen | Účel |
| --- | --- |
| `background` | Nastavuje pozadí na úrovni master slide. |
| `shapes` | Uchovává tvary umístěné na masteru, jako jsou loga, rámy obrázků a sdílený text. |
| `layout_slides` | Uchovává layout slidů patřící k masteru. |
| `theme_manager` | Poskytuje přístup k API motivu masteru. |
| `header_footer_manager` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřízené rozvržení. |
| `get_depending_slides` | Vrací normální snímky, které závisí na masteru prostřednictvím svých layoutů. |

## **Přidání obrázku do slide masteru**

Když přidáte obrázek do master slide, objeví se na snímcích, které používají rozvržení z tohoto masteru. Je to užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidá logo na první master slide:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Pro více informací o rámečcích obrázků viz [Picture Frame](/slides/cs/python-net/picture-frame/).

## **Ovládání viditelnosti grafiky masteru**

Použijte [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/show_master_shapes/) k skrytí zděděné grafiky masteru, jako jsou loga nebo dekorativní tvary, aniž byste je mazali z masteru. Nastavte [Slide.show_master_shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/show_master_shapes/) na `False` na snímku, který má tyto grafiky vynechat, a ponechte jej `True` na snímcích, které je mají zobrazovat.

Následující samostatný příklad vytvoří modrý dekorativní pás na masteru a dvou snímcích, které používají stejné prázdné rozvržení. Pás je viditelný na prvním snímku a skrytý na druhém. Nevstupní prezentace ani obrázek nejsou vyžadovány.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Příklad používá rozvržení **Blank** dodávané s novou prezentací a odstraňuje vlastní zástupné objekty počátečního snímku.

### **Zvolte rozsah nastavení**

Normální snímek používá svůj master prostřednictvím [Slide.layout_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/layout_slide/) a [LayoutSlide.master_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/master_slide/). Nastavení vlastnosti na jednotlivém snímku ovlivní jen tento snímek. Nastavení [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/show_master_shapes/) na `False` skryje grafiku masteru pro snímky, které používají toto sdílené rozvržení, i když jejich vlastní nastavení je `True`. Chcete-li skrýt grafiku jen na jednom snímku, změňte vlastnost snímku a ponechte sdílené rozvržení beze změny.

Nastavení není podporováno jako řízení viditelnosti přímo na master slide. Na masteru vždy vrací `False` a při přiřazení `True` vyvolá výjimku. Použijte ho na normální snímek nebo na layout.

### **Rozlišení grafiky od pozadí**

| Operace | Efekt |
| --- | --- |
| Skrýt grafiku masteru | Řídí viditelnost zděděných tvarů masteru bez jejich mazání nebo změny tvarů snímku. |
| Změnit výplň pozadí snímku | Mění barvu, gradient nebo obrázek pozadí. Grafika masteru jsou samostatné tvary a mohou zůstávat viditelné nad tímto pozadím. Viz [Presentation Background](/slides/cs/python-net/presentation-background/). |
| Smazat tvar z masteru | Odstraní sdílený zdrojový tvar, takže již není dostupný pro žádný snímek používající tento master. |

## **Práce se zástupnými objekty**

Zástupné objekty jsou normálně definovány na layout slidech. Master slide poskytuje sdílený styl a motiv, který tyto layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou dostupné a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Chcete-li přidat nové zástupné objekty pomocí Aspose.Slides, pracujte s layout slide, který patří k masteru:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Můžete také formátovat tvary zástupných objektů, které již na master slide existují. Následující příklad najde zástupný objekt titulu a použije lineární gradientní výplň:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formátovaný zástupný objekt titulu zděděný normálními snímky](slide-master_8.png)

Pro více možností formátování zástupných objektů a textu viz [Set Prompt Text in Placeholder](/slides/cs/python-net/manage-placeholder/) a [Text Formatting](/slides/cs/python-net/text-formatting/).

## **Změna pozadí slide masteru**

Master pozadí je zděděno layouty a snímky, které jej nepřepisují. Následující příklad nastaví jednotnou barvu pozadí pro první master slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Pro související témata viz [Presentation Background](/slides/cs/python-net/presentation-background/) a [Presentation Theme](/slides/cs/python-net/presentation-theme/).

## **Klonování slide masteru do jiné prezentace**

Použijte metodu `add_clone` na třídě [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/) k zkopírování master slide do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, viz [Clone Slides](/slides/cs/python-net/clone-slides/).

## **Přidání více slide masterů**

Prezentace může obsahovat několik master slidů. Je to užitečné, když různé sekce vyžadují odlišné brandování, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master slidů](slide-master_9.jpg)

Následující příklad klonuje výchozí master, dá klonu jiné pozadí, získá prázdné rozvržení pod tímto klonovaným masterem a přidá nový snímek založený na tomto rozvržení:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Porovnání slide masterů**

Master slid lze porovnat metodou `equals` zděděnou ze třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/) . Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Pro více informací viz [Compare Presentation Slides](/slides/cs/python-net/compare-slides/).

## **Nastavení zobrazení Slide Master jako výchozího zobrazení**

Použijte vlastnost `last_view` na [ViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/) prezentace k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Pro další nastavení zobrazení viz [Save Presentation](/slides/cs/python-net/save-presentation/).

## **Odstranění nepoužívaných master slidů**

Prezentace někdy obsahují master slid, který již není používán žádným normálním snímkem. Odstranění nepoužívaných masterů může zmenšit velikost souboru a zjednodušit údržbu šablony.

Použijte `remove_unused` k odstranění nepoužívaných masterů z kolekce `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Můžete také použít low-code metodu `remove_unused_master_slides` z třídy [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide masterem a layout slidem?**  
Slide master definuje sdílená nastavení designu, jako jsou motiv, pozadí, společné tvary a styly textu. Layout slide patří k master slide a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout slide, takže dědí jak od layoutu, tak od masteru.

**Může jedna prezentace obsahovat několik slide masterů?**  
Ano. Prezentace může obsahovat několik slide masterů. Používejte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo brandování.

**Mám přidávat zástupné objekty na master slide nebo na layout slide?**  
Ve většině případů přidávejte zástupné objekty na layout slid. Sdílené vizuální prvky a formátování umístěte na master slide a obsahové zástupné objekty na layouty, které budou použity normálními snímky.

**Mohu smazat master slide, který je stále používán?**  
Ne. Master slide, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky do layoutů pod jiný master, nebo použijte metodu pro úklid nepoužívaných masterů, která odstraňuje jen mastery, které nejsou v použití.