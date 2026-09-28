---
title: Spravovat hlavní snímky prezentace v Pythonu přes Java
linktitle: Hlavní snímek
type: docs
weight: 70
url: /cs/python-java/slide-master/
keywords:
- hlavní snímek
- hlavní snímek
- PPT hlavní snímek
- více hlavních snímků
- porovnat hlavní snímky
- pozadí
- rezervovaná oblast
- klonovat hlavní snímek
- kopírovat hlavní snímek
- duplikovat hlavní snímek
- nepoužitý hlavní snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte hlavní snímky v Aspose.Slides pro Python přes Java: přístup, úpravy, klonování, porovnávání a odstraňování hlavních snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**Hlavní snímek** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava hlavního snímku obvyklý způsob, jak udržet prezentaci konzistentní, aniž by se opakovalo stejné formátování na každém snímku.

Aspose.Slides for Python via Java podporuje stejný model. Prezentace může obsahovat jeden nebo více hlavních snímků a každý hlavní snímek může obsahovat několik snímků rozvržení. Normální snímky se obvykle nepřipojují přímo k hlavnímu snímku. Místo toho normální snímek používá snímek rozvržení a tento snímek rozvržení patří k hlavnímu snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.
1. **Layout slide** – definuje konkrétní uspořádání rezervovaných oblastí a formátování na úrovni rozvržení.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden snímek rozvržení.

![Hierarchie hlavních snímků, snímků rozvržení a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je hlavní snímek reprezentován třídou [MasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/). Všechny hlavní snímky v prezentaci jsou dostupné přes kolekci [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters), která je reprezentována třídou [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vítězí konkrétnější úroveň. Například pokud hlavní snímek a snímek rozvržení oba definují pozadí, snímky založené na tomto rozvržení používají pozadí rozvržení. Další informace o snímcích rozvržení najdete v [Apply or Change Slide Layouts](/slides/cs/python-java/slide-layout/).
{{% /alert %}}

## **Přístup k hlavním snímkům**

V PowerPointu můžete otevřít zobrazení **Slide Master** z **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci [Presentation.getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getMasters) pro přístup k hlavním snímkům:

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

Můžete také získat hlavní snímek použité normálním snímkem přes jeho rozvržení:

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

Hlavní snímek je objekt podobný snímku. Dědí z [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/), takže vystavuje mnoho stejných vlastností snímku používaných normálními a rozvržovacími snímky. Specifické členy hlavního snímku jsou uvedeny na stránce API [MasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/).

Mezi často používané členy hlavního snímku patří:

| Member | Purpose |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getBackground) | Nastavuje pozadí snímku na úrovni hlavního snímku. |
| [getShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getShapes) | Ukládá tvary umístěné na hlavním snímku, jako jsou loga, rámečky obrázků a sdílený text. |
| [getLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getLayoutSlides) | Ukládá snímky rozvržení, které patří k hlavnímu snímku. |
| [getThemeManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getThemeManager) | Poskytuje přístup k API motivu hlavního snímku. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Řídí záhlaví, zápatí, data a čísla snímků pro hlavní snímek a jeho podřízené rozvržení. |
| [getDependingSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getDependingSlides) | Vrací normální snímky, které závisí na hlavním snímku prostřednictvím jejich rozvržení. |

## **Přidání obrázku na hlavní snímek**

Když přidáte obrázek na hlavní snímek, objeví se na snímcích, které používají rozvržení z tohoto hlavního snímku. To je užitečné pro loga, vodoznaky, dekorativní pásy a jiné opakující se vizuální prvky.

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

Další informace o rámečcích obrázků najdete v [Picture Frame](/slides/cs/python-java/picture-frame/).

## **Ovládání viditelnosti grafiky hlavního snímku**

Použijte [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#setShowMasterShapes) k skrytí zděděné grafiky hlavního snímku, jako jsou loga nebo dekorativní tvary, aniž byste je smazali z hlavního snímku. Při volání `False` na [Slide.setShowMasterShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setShowMasterShapes) na snímku, který by měl tyto grafiky vynechat, a ponechte `True` na snímcích, které je mají zobrazit.

Následující samostatný příklad vytváří modrý dekorativní pás na hlavním snímku a dvou snímcích, které používají stejné prázdné rozvržení. Pás je viditelný na prvním snímku a skrytý na druhém. Nevstupní prezentace ani obrázek nejsou vyžadovány.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Příklad používá rozvržení **Blank**, které je součástí nové prezentace, a odstraňuje vlastní rezervované oblasti úvodního snímku.

### **Zvolte rozsah nastavení**

Normální snímek používá svůj hlavní snímek přes [Slide.getLayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getLayoutSlide) a [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#getMasterSlide). Nastavení vlastnosti na jednotlivém snímku ovlivní jen tento snímek. Předání `False` do [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/#setShowMasterShapes) skryje grafiku hlavního snímku pro snímky, které používají toto sdílené rozvržení, i když jejich vlastní nastavení je `True`. Pro skrytí grafiky jen na jednom snímku změňte vlastnost snímku a nechte sdílené rozvržení beze změny.

Nastavení není podporováno jako řízení viditelnosti přímo na hlavním snímku. Na hlavním snímku [getShowMasterShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#getShowMasterShapes) vždy vrací `False` a předání `True` do [setShowMasterShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/#setShowMasterShapes) vyvolá výjimku. Použijte jej na normální snímek nebo na rozvržení.

### **Rozlišování grafiky od pozadí**

| Operace | Výsledek |
| --- | --- |
| Hide master graphics | Řídí viditelnost zděděných tvarů hlavního snímku, aniž by je mazal nebo měnil vlastní tvary snímku. |
| Change the slide background fill | Mění barvu, gradient nebo obrázek pozadí. Grafika hlavního snímku je samostatný tvar a může zůstat viditelná nad tímto pozadím. Viz [Presentation Background](/slides/cs/python-java/presentation-background/). |
| Delete a shape from the master | Odstraňuje sdílený zdrojový tvar, takže již není dostupný žádnému snímku používajícímu tento hlavní snímek. |

## **Práce s rezervovanými oblastmi**

Rezervované oblasti jsou normálně definovány na snímcích rozvržení. Hlavní snímek poskytuje sdílený styl a motiv, který tyto rozvržení dědí, zatímco každé rozvržení rozhoduje, které rezervované oblasti jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy rezervovaných oblastí k dispozici v zobrazení **Slide Master**.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových rezervovaných oblastí s Aspose.Slides pracujte s rozvržením, které patří k hlavnímu snímku:

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

Můžete také formátovat tvary rezervovaných oblastí, které již na hlavním snímku existují. Následující příklad najde rezervovanou oblast nadpisu a aplikuje lineární gradientní výplň:

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

![Formátovaný zástupný prvek nadpisu zděděný normálními snímky](slide-master_8.png)

Pro další možnosti formátování rezervovaných oblastí a textu viz [Set Prompt Text in Placeholder](/slides/cs/python-java/manage-placeholder/) a [Text Formatting](/slides/cs/python-java/text-formatting/).

## **Změna pozadí hlavního snímku**

Pozadí hlavního snímku je zděděno rozvrženími a snímky, které jej nepřepíší. Následující příklad nastavuje jednotnou barvu pozadí pro první hlavní snímek:

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

Pro související témata viz [Presentation Background](/slides/cs/python-java/presentation-background/) a [Presentation Theme](/slides/cs/python-java/presentation-theme/).

## **Klonování hlavního snímku do jiné prezentace**

Použijte [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslidecollection/#addClone) ke kopírování hlavního snímku do jiné prezentace. Zkopírovaný hlavní snímek pak může být použit rozvrženími a snímky v cílové prezentaci.

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

Pokud potřebujete klonovat normální snímky společně s jejich hlavním snímkem, viz [Clone Slides](/slides/cs/python-java/clone-slides/).

## **Přidání více hlavních snímků**

Prezentace může obsahovat více hlavních snímků. To je užitečné, když různé sekce vyžadují odlišné značení, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu hlavních snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí hlavní snímek, nastaví klonu jiné pozadí, vytvoří rozvržení pod tímto klonovaným hlavním snímkem a přidá nový snímek založený na tomto rozvržení:

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

Hlavní snímky lze porovnávat pomocí metody [equals](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#equals) zděděné z [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Neporovnává jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty rezervovaných oblastí, jako je aktuální datum.

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

Pro více informací viz [Compare Presentation Slides](/slides/cs/python-java/compare-slides/).

## **Nastavení zobrazení hlavního snímku jako výchozího zobrazení**

Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setLastView) na [ViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevírá prezentaci v zobrazení **Slide Master**:

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

Pro další nastavení zobrazení viz [Save Presentation](/slides/cs/python-java/save-presentation/).

## **Odstranění nepoužívaných hlavních snímků**

Prezentace někdy obsahují hlavní snímky, které již žádný normální snímek nepoužívá. Odstranění nepoužívaných hlavních snímků může snížit velikost souboru a zjednodušit správu šablon.

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

Můžete také použít low‑code metodu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

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

Hlavní snímek definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Snímek rozvržení patří k hlavnímu snímku a určuje konkrétní uspořádání rezervovaných oblastí. Normální snímek používá snímek rozvržení, takže dědí jak z rozvržení, tak z hlavního snímku.

**Může jedna prezentace obsahovat několik hlavních snímků?**

Ano. Prezentace může obsahovat několik hlavních snímků. Používejte více hlavních snímků, když různé sekce potřebují odlišné vizuální systémy nebo značení.

**Mám přidávat rezervované oblasti na hlavní snímek nebo na snímek rozvržení?**

Ve většině případů přidávejte rezervované oblasti na snímky rozvržení. Sdílené vizuální prvky a formátování umístěte na hlavní snímek a obsahové rezervované oblasti na rozvržení, která budou používat normální snímky.

**Mohu smazat hlavní snímek, který je stále používán?**

Ne. Hlavní snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na rozvržení pod jiný hlavní snímek nebo použijte metodu pro úklid nepoužívaných hlavních snímků, která odstraní pouze hlavní snímky, které nejsou použity.