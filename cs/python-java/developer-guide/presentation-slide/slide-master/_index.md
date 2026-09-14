---
title: Správa hlavních snímků prezentace v Pythonu prostřednictvím Java
linktitle: Hlavní snímek
type: docs
weight: 70
url: /cs/python-java/slide-master/
keywords:
- hlavní snímek
- hlavní snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnání hlavních snímků
- pozadí
- zástupný objekt
- klonovat hlavní snímek
- kopírovat hlavní snímek
- duplikovat hlavní snímek
- nepoužívaný hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte hlavní snímky v Aspose.Slides pro Python přes Java: přístup, úprava, klonování, porovnávání a odstraňování hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**Hlavní snímek** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava hlavního snímku obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for Python via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních snímků a každý hlavní snímek může obsahovat několik snímků rozvržení. Normální snímky se obvykle nepřipojují přímo k hlavnímu snímku. Místo toho normální snímek používá snímek rozvržení, který patří k hlavnímu snímku.

Hierarchie je:

1. **Hlavní snímek** – definuje sdílený design a motiv.  
1. **Snímek rozvržení** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni rozvržení.  
1. **Normální snímek** – obsahuje skutečný obsah prezentace a používá jeden snímek rozvržení.

![Hierarchie hlavních snímků, snímků rozvržení a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je hlavní snímek reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/). Všechny hlavní snímky v prezentaci jsou k dispozici prostřednictvím kolekce [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters), která je reprezentována třídou [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vítězí konkrétnější úroveň. Například pokud hlavní snímek a snímek rozvržení oba definují pozadí, snímky založené na tomto rozvržení použijí pozadí rozvržení. Pro více informací o snímcích rozvržení viz [Použít nebo změnit rozvržení snímků](/slides/cs/python-java/slide-layout/).
{{% /alert %}}

## **Přístup k hlavním snímkům**

V PowerPointu můžete otevřít zobrazení Hlavního snímku přes **Zobrazení** > **Hlavní snímek**.

![Příkaz Hlavní snímek na kartě Zobrazení v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters) k získání hlavních snímků:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Můžete také získat hlavní snímek použitý normálním snímkem prostřednictvím jeho rozvržení:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Co obsahuje hlavní snímek**

Hlavní snímek je objekt podobný snímku. Dědí z [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/), takže poskytuje mnoho stejných vlastností snímku používaných normálními a rozvržovacími snímky. Členové specifické pro hlavní snímek jsou uvedeni na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/).

Mezi často používané členy hlavního snímku patří:

| Člen | Účel |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getBackground) | Nastavuje pozadí snímku na úrovni hlavního snímku. |
| [getShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getShapes) | Ukládá tvary umístěné na hlavním snímku, jako jsou loga, rámečky obrázků a sdílený text. |
| [getLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getLayoutSlides) | Ukládá snímky rozvržení, které patří k hlavnímu snímku. |
| [getThemeManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getThemeManager) | Poskytuje přístup k API motivu hlavního snímku. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Řídí záhlaví, zápatí, datum a číslo snímku pro hlavní snímek a jeho podřízené rozvržení. |
| [getDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getDependingSlides) | Vrací normální snímky, které jsou závislé na hlavním snímku prostřednictvím jejich rozvržení. |

## **Přidání obrázku do hlavního snímku**

Když přidáte obrázek do hlavního snímku, objeví se na snímcích, které používají rozvržení z tohoto hlavního snímku. To je užitečné pro loga, vodoznaky, dekorativní pásky a další opakované vizuální prvky.

Následující příklad přidává logo na první hlavní snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro více informací o rámečcích obrázků viz [Rámec obrázku](/slides/cs/python-java/picture-frame/).

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na snímcích rozvržení. Hlavní snímek poskytuje sdílený styl a motiv, který tyto rozvržení dědí, zatímco každé rozvržení rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Hlavního snímku.

![Příkaz Vložit zástupný objekt v zobrazení Hlavního snímku v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů pomocí Aspose.Slides pracujte se snímkem rozvržení, který patří k hlavnímu snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Můžete také formátovat tvary zástupných objektů, které již na hlavním snímku existují. Následující příklad najde zástupný objekt názvu a použije lineární gradientní výplň:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Formátovaný zástupný objekt názvu děděný normálními snímky](slide-master_8.png)

Pro více možností formátování zástupných objektů a textu viz [Nastavit text výzvy ve zástupném objektu](/slides/cs/python-java/manage-placeholder/) a [Formátování textu](/slides/cs/python-java/text-formatting/).

## **Změna pozadí hlavního snímku**

Pozadí hlavního snímku je děděno rozvrženími a snímky, které jej nepřepisují. Následující příklad nastavuje jednolitou barvu pozadí pro první hlavní snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro související témata viz [Pozadí prezentace](/slides/cs/python-java/presentation-background/) a [Motiv prezentace](/slides/cs/python-java/presentation-theme/).

## **Klonování hlavního snímku do jiné prezentace**

Použijte [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#addClone) k zkopírování hlavního snímku do jiné prezentace. Zkopírovaný hlavní snímek pak může být použit rozvrženími a snímky v cílové prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Pokud potřebujete klonovat normální snímky spolu s jejich hlavním snímkem, viz [Klonovat snímky](/slides/cs/python-java/clone-slides/).

## **Přidání více hlavních snímků**

Prezentace může obsahovat více hlavních snímků. To je užitečné, když různé sekce vyžadují odlišné brandování, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu hlavních snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí hlavní snímek, dá klonu jiné pozadí, vytvoří rozvržení pod tímto klonovaným hlavním snímkem a přidá nový snímek založený na tomto rozvržení:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Porovnání hlavních snímků**

Hlavní snímky lze porovnat pomocí metody [equals](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#equals) zděděné z [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje unikátní identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Pro více informací viz [Porovnat snímky prezentace](/slides/cs/python-java/compare-slides/).

## **Nastavit zobrazení Hlavního snímku jako výchozí zobrazení**

Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setLastView) na [ViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/), abyste kontrolovali, které zobrazení PowerPoint otevře jako první. Následující příklad otevírá prezentaci v zobrazení Hlavního snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro více nastavení zobrazení viz [Uložit prezentaci](/slides/cs/python-java/save-presentation/).

## **Odstranění nepoužívaných hlavních snímků**

Prezentace někdy obsahují hlavní snímky, které již nejsou používány žádnými normálními snímky. Odstranění nepoužívaných hlavních snímků může snížit velikost souboru a zjednodušit údržbu šablon.

Použijte [removeUnused](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#removeUnused) k odstranění nepoužívaných hlavních snímků z kolekce [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Můžete také použít low-code metodu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a snímkem rozvržení?**

Hlavní snímek definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Snímek rozvržení patří k hlavnímu snímku a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá snímek rozvržení, takže dědí jak z rozvržení, tak z hlavního snímku.

**Může jedna prezentace obsahovat několik hlavních snímků?**

Ano. Prezentace může obsahovat několik hlavních snímků. Použijte více hlavních snímků, když různé sekce potřebují odlišné vizuální systémy nebo brandování.

**Mám přidávat zástupné objekty do hlavního snímku nebo do snímku rozvržení?**

Ve většině případů přidávejte zástupné objekty do snímků rozvržení. Sdílené vizuální prvky a společné formátování umístěte na hlavní snímek, poté vložte zástupné objekty obsahu do rozvržení, která budou používat normální snímky.

**Mohu smazat hlavní snímek, který je stále používán?**

Ne. Hlavní snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky do rozvržení pod jiný hlavní snímek, nebo použijte metodu úklidu nepoužívaných hlavních snímků, která odstraňuje pouze hlavní snímky, které nejsou v použití.