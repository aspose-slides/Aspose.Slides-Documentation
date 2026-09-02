---
title: Správa master slideů prezentace v Pythonu
linktitle: Master slide
type: docs
weight: 80
url: /cs/python-net/slide-master/
keywords:
- master snímku
- master snímku
- PPT master snímku
- více master snímků
- porovnání master snímků
- pozadí
- zástupný prvek
- klonovat master snímek
- kopírovat master snímek
- duplikovat master snímek
- nepoužívaný master snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte master slide v Aspose.Slides pro Python pomocí .NET: přístup, úpravy, klonování, porovnávání a odstraňování master slide v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**slide master** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení tématu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides pro Python via .NET podporuje stejný model. Prezentace může obsahovat jeden nebo více master slideů a každý master slide může obsahovat několik layout slideů. Normální snímky se obvykle nepřímo neodkazují na master slide. Místo toho normální snímek používá layout slide, který patří k master slide.

Hierarchie je:

1. **Slide master** – definuje sdílený design a téma.  
1. **Layout slide** – definuje konkrétní uspořádání placeholderů a formátování na úrovni rozvržení.  
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout slide.

![Hierarchie master slideů, layout slideů a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) . Všechny master slide v prezentaci jsou dostupné prostřednictvím kolekce `Presentation.masters`.

{{% alert color="info" title="Dědičnost" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud master slide i layout slide oba definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout slidech najdete v [Apply or Change Slide Layouts](/slides/cs/python-net/slide-layout/).
{{% /alert %}}

## **Přístup k Slide Masterům**

V PowerPointu můžete otevřít zobrazení Slide Masteru z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `masters` pro přístup k master slideům:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Můžete také získat master slide použité normálním snímkem přes jeho layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Co Slide Master obsahuje**

Master slide je objekt podobný snímku. Dědí běžné chování snímku z třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/) , takže poskytuje mnoho stejných vlastností snímků používaných normálními a layout snímky. Členové specifické pro master jsou uvedeni na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/) .

Často používaní členové master slide zahrnují:

| Člen | Účel |
| --- | --- |
| `background` | Nastavuje pozadí slide na úrovni masteru. |
| `shapes` | Ukládá tvary umístěné na masteru, jako loga, rámečky obrázků a sdílený text. |
| `layout_slides` | Ukládá layout slide patřící k masteru. |
| `theme_manager` | Poskytuje přístup k API master tématu. |
| `header_footer_manager` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřízené layouty. |
| `get_depending_slides` | Vrací normální snímky, které závisí na masteru přes své layouty. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do master slide, objeví se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásky a další opakující se vizuální prvky.

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

Další informace o rámečcích obrázků najdete v [Picture Frame](/slides/cs/python-net/picture-frame/).

## **Práce s placeholdery**

Placeholdery jsou obvykle definovány na layout slidech. Master slide poskytuje sdílený styl a téma, které layouty zdědí, zatímco každý layout rozhoduje, které placeholdery jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy placeholderů dostupné v zobrazení Slide Master.

![Příkaz Vložit placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových placeholderů s Aspose.Slides pracujte s layout slidem patřícím k masteru:

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

Můžete také formátovat tvary placeholderů, které již na master slide existují. Následující příklad najde placeholder nadpisu a použije lineární gradientní výplň:

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

![Formátovaný placeholder nadpisu zděděný normálními snímky](slide-master_8.png)

Další možnosti formátování placeholderů a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/python-net/manage-placeholder/) a [Text Formatting](/slides/cs/python-net/text-formatting/).

## **Změna pozadí Slide Masteru**

Pozadí masteru je zděděno layouty a snímky, které jej nepřepíší. Následující příklad nastavuje jednotnou barvu pozadí pro první master slide:

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

## **Klónování Slide Masteru do jiné prezentace**

Použijte metodu `add_clone` na třídě [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/) pro zkopírování master slide do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, podívejte se na [Clone Slides](/slides/cs/python-net/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více master slideů. To je užitečné, když různé sekce vyžadují odlišnou značku, strukturu stránky nebo nastavení tématu.

![Příkazy PowerPointu pro vkládání a správu master slideů](slide-master_9.jpg)

Následující příklad klonuje výchozí master, nastaví klonu jiné pozadí, získá prázdný layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

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

## **Porovnání Slide Masterů**

Master slide lze porovnat pomocí metody `equals` zděděné z třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/) . Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty placeholderů, jako je aktuální datum.

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

Další informace najdete v [Compare Presentation Slides](/slides/cs/python-net/compare-slides/).

## **Nastavit zobrazení Slide Master jako výchozí zobrazení**

Použijte vlastnost `last_view` na objektu prezentace [ViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/) pro kontrolu zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Další nastavení zobrazení viz [Save Presentation](/slides/cs/python-net/save-presentation/).

## **Odstranění nepoužívaných Master Slideů**

Prezentace někdy obsahují master slide, které již nejsou použity žádnými normálními snímky. Odstranění nepoužívaných masterů může snížit velikost souboru a zjednodušit údržbu šablon.

Použijte `remove_unused` pro odstranění nepoužívaných masterů z kolekce `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Můžete také použít nízkokódovou metodu `remove_unused_master_slides` ze třídy [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Jaký je rozdíl mezi slide master a layout slide?

Slide master definuje sdílená nastavení designu, jako jsou téma, pozadí, společné tvary a styly textu. Layout slide patří k master slide a definuje konkrétní uspořádání placeholderů. Normální snímek používá layout slide, a tak zdědí jak z layoutu, tak z masteru.

### Může jedna prezentace obsahovat několik slide masterů?

Ano. Prezentace může obsahovat několik slide masterů. Používejte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značkování.

### Mám přidávat placeholdery do master slide nebo do layout slide?

Ve většině případů přidávejte placeholdery do layout slide. Na master slide umístěte sdílené vizuální prvky a formátování, na layouty pak vložte obsahové placeholdery, které budou používat normální snímky.

### Mohu smazat master slide, který je stále používán?

Ne. Master slide, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesunte tyto snímky na layouty pod jiným masterem nebo použijte metodu úklidu nevyužitých masterů, která odstraní pouze master slide, které nejsou v používání.