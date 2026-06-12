---
title: Správa hlavních snímků prezentace v Pythonu
linktitle: Hlavní snímek
type: docs
weight: 80
url: /cs/python-net/slide-master/
keywords:
- hlavní snímek
- hlavní snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnání hlavních snímků
- pozadí
- zástupce
- klonování hlavního snímku
- kopírování hlavního snímku
- duplikování hlavního snímku
- nepoužívaný hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte hlavní snímky v Aspose.Slides pro Python prostřednictvím .NET: přístup, úpravy, klonování, porovnání a odstraňování hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**Hlavní snímek** definuje společná nastavení designu pro skupinu snímků. Může obsahovat běžné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava hlavního snímku obvyklý způsob, jak udržet prezentaci jednotnou, aniž by se opakovalo stejné formátování na každém snímku.

Aspose.Slides for Python via .NET podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních snímků a každý hlavní snímek může obsahovat několik snímků rozložení. Normální snímky obvykle neodkazují přímo na hlavní snímek. Místo toho normální snímek používá snímek rozložení a tento snímek rozložení patří k hlavnímu snímku.

Hierarchie je:

1. **Hlavní snímek** – definuje společný design a motiv.
1. **Snímek rozložení** – definuje konkrétní uspořádání zástupců a formátování na úrovni rozložení.
1. **Normální snímek** – obsahuje skutečný obsah prezentace a používá jeden snímek rozložení.

![Hierarchie hlavních snímků, snímků rozložení a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je hlavní snímek reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/). Všechny hlavní snímky v prezentaci jsou dostupné přes kolekci `Presentation.masters`.

{{% alert color="info" title="Dědičnost" %}}
Když je stejná vlastnost definována na více úrovních, vítězí konkrétnější úroveň. Například pokud hlavní snímek i snímek rozložení definují pozadí, snímky založené na tomto rozložení použijí pozadí rozložení. Další informace o snímcích rozložení najdete v [Apply or Change Slide Layouts](/python-net/slide-layout/).
{{% /alert %}}

## **Přístup k hlavním snímkům**

V PowerPointu můžete otevřít zobrazení hlavního snímku z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `masters` k přístupu k hlavním snímkům:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Můžete také získat hlavní snímek použité normálním snímkem přes jeho rozložení:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Co obsahuje hlavní snímek**

Hlavní snímek je objekt podobný snímku. Dědí společné chování snímků z třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/), takže poskytuje mnoho stejných vlastností snímků používaných normálními i snímky rozložení. Specifické členy hlavního snímku jsou uvedeny na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/).

Mezi často používané členy hlavního snímku patří:

| Člen | Účel |
| --- | --- |
| `background` | Nastavuje pozadí na úrovni hlavního snímku. |
| `shapes` | Ukládá tvary umístěné na hlavním snímku, například loga, rámy obrázků a sdílený text. |
| `layout_slides` | Ukládá snímky rozložení, které patří k hlavnímu snímku. |
| `theme_manager` | Poskytuje přístup k API motivu hlavního snímku. |
| `header_footer_manager` | Řídí záhlaví, zápatí, data a čísla snímků pro hlavní snímek a jeho podřízená rozložení. |
| `get_depending_slides` | Vrací normální snímky, které jsou závislé na hlavním snímku prostřednictvím svých rozložení. |

## **Přidání obrázku do hlavního snímku**

Když přidáte obrázek do hlavního snímku, objeví se na snímcích, které používají rozložení z tohoto hlavního snímku. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidá logo do prvního hlavního snímku:

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

Další informace o rámech obrázků naleznete v [Picture Frame](/python-net/picture-frame/).

## **Práce se zástupci**

Zástupci jsou obvykle definováni na snímcích rozložení. Hlavní snímek poskytuje společný styl a motiv, které tyto rozložení dědí, zatímco každé rozložení rozhoduje, které zástupce jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupce dostupné v zobrazení hlavního snímku.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Chcete-li přidat nové zástupce s Aspose.Slides, pracujte se snímkem rozložení, který patří k hlavnímu snímku:

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

Můžete také formátovat tvary zástupců, které již na hlavním snímku existují. Následující příklad najde zástupce nadpisu a použije lineární gradientní výplň:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Naformátovaný zástupce nadpisu zděděný normálními snímky](slide-master_8.png)

Další možnosti formátování zástupců a textu najdete v [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) a [Text Formatting](/python-net/text-formatting/).

## **Změna pozadí hlavního snímku**

Pozadí hlavního snímku je děděno rozloženími a snímky, které jej nepřepíší. Následující příklad nastaví jednobarevné pozadí pro první hlavní snímek:

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

Související témata najdete v [Presentation Background](/python-net/presentation-background/) a [Presentation Theme](/python-net/presentation-theme/).

## **Klonování hlavního snímku do jiné prezentace**

Použijte metodu `add_clone` na třídě [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/), abyste zkopírovali hlavní snímek do jiné prezentace. Zkopírovaný hlavní snímek pak může být použit rozloženími a snímky v cílové prezentaci.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete klonovat normální snímky spolu s jejich hlavním snímkem, podívejte se na [Clone Slides](/python-net/clone-slides/).

## **Přidání více hlavních snímků**

Prezentace může obsahovat více hlavních snímků. To je užitečné, když různé sekce vyžadují odlišnou značku, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu hlavních snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí hlavní snímek, dá klonu jiné pozadí, získá prázdné rozložení pod tímto klonovaným hlavním snímkem a přidá nový snímek založený na tomto rozložení:

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

## **Porovnání hlavních snímků**

Hlavní snímky lze porovnat pomocí metody `equals` zděděné z třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, nebo dynamické hodnoty zástupců, například aktuální datum.

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

Další informace naleznete v [Compare Presentation Slides](/python-net/compare-slides/).

## **Nastavení zobrazení hlavního snímku jako výchozího zobrazení**

Použijte vlastnost `last_view` na objektu prezentace [ViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/), abyste určili, jaké zobrazení PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení hlavního snímku:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Další nastavení zobrazení najdete v [Save Presentation](/python-net/save-presentation/).

## **Odstranění nepoužívaných hlavních snímků**

Prezentace někdy obsahují hlavní snímky, které již nejsou používány žádnými normálními snímky. Odstranění nepoužívaných hlavních snímků může snížit velikost souboru a zjednodušit údržbu šablon.

Použijte `remove_unused` k odstranění nepoužívaných hlavních snímků ze sbírky `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Můžete také použít nízko‑kódovou metodu `remove_unused_master_slides` ze třídy [Compress](https://reference.aspose.com/slides/cs/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a snímkem rozložení?**  
Hlavní snímek definuje společná nastavení designu jako motiv, pozadí, běžné tvary a styly textu. Snímek rozložení patří k hlavnímu snímku a určuje konkrétní uspořádání zástupců. Normální snímek používá snímek rozložení, takže dědí jak z rozložení, tak z hlavního snímku.

**Může jedna prezentace obsahovat několik hlavních snímků?**  
Ano. Prezentace může obsahovat několik hlavních snímků. Použijte více hlavních snímků, když různé sekce vyžadují odlišné vizuální systémy nebo značkování.

**Mám přidávat zástupce na hlavní snímek nebo na snímek rozložení?**  
Ve většině případů přidávejte zástupce na snímky rozložení. Na hlavní snímek umístěte sdílené vizuální prvky a formátování, na rozložení pak vložte obsahové zástupce, které budou použity normálními snímky.

**Mohu smazat hlavní snímek, který je stále používán?**  
Ne. Hlavní snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na rozložení pod jiný hlavní snímek nebo použijte metodu úklidu nepoužívaných hlavních snímků, která odstraní pouze ty hlavní snímky, které se nepoužívají.