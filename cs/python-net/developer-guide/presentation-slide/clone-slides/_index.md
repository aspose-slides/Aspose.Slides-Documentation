---
title: Klonování snímků PowerPoint v Pythonu
linktitle: Klonovat snímky
type: docs
weight: 40
url: /cs/python-net/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Rychle klonujte nebo duplikujte snímky PowerPoint pomocí Aspose.Slides for Python via .NET. Sledujte naše přehledné příklady kódu a tipy pro automatizaci tvorby PPT během několika sekund, zvýšte produktivitu a eliminujte ruční práci."
---
## **Úvod**

Klónování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides také umožňuje zkopírovat (klonovat) libovolný snímek a poté vložit klonovaný snímek do aktuální prezentace nebo do jiné otevřené prezentace. Klonování snímku vytvoří nový snímek, který vývojáři mohou upravovat, aniž by ovlivnili původní snímek. Existuje několik způsobů, jak klonovat snímek:

- Klonovat na konci prezentace.
- Klonovat na jiné pozici v rámci prezentace.
- Klonovat na konci jiné prezentace.
- Klonovat na jiné pozici v jiné prezentaci.
- Klonovat na konkrétní pozici v jiné prezentaci.

V Aspose.Slides for Python via .NET poskytuje [kolekce snímků](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) zpřístupněná objektem [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) metody `add_clone` a `insert_clone` pro provedení těchto typů klonování snímků.

## **Instalace**

```bash
pip install aspose.slides
```

## **Klonovat na konci ve stejné prezentaci**

Pokud chcete klonovat snímek ve stejné prezentaci a připojit jej na konec existujících snímků, použijte metodu `add_clone`. Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte kolekci snímků z objektu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Zavolejte metodu `add_clone` na [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/), předáním snímku, který má být klonován.
1. Uložte upravenou prezentaci.

V níže uvedeném příkladu je první snímek (index 0) klonován a připojen na konec prezentace.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci.
    presentation.slides.add_clone(presentation.slides[0])
    # Uložte upravenou prezentaci na disk.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat na konkrétní pozici ve stejné prezentaci**

Pokud chcete klonovat snímek ve stejné prezentaci a umístit jej na jinou pozici, použijte metodu `insert_clone`:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte kolekci snímků z objektu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Zavolejte metodu `insert_clone` na [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/), předáním snímku, který má být klonován, a cílového indexu pro novou pozici.
1. Uložte upravenou prezentaci.

V níže uvedeném příkladu je snímek s indexem 1 (pozice 2) klonován na index 2 (pozice 3) ve stejné prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klonujte požadovaný snímek na zadanou pozici (index) ve stejné prezentaci.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Uložte upravenou prezentaci na disk.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat na konci jiné prezentace**

Pokud potřebujete klonovat snímek z jedné prezentace a připojit jej na konec jiné prezentace:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro zdrojovou prezentaci (ta, která obsahuje snímek k klonování).
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro cílovou prezentaci (kam bude snímek přidán).
1. Získejte kolekci snímků z cílové prezentace.
1. Zavolejte `add_clone` na cílové [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/), předáním snímku ze zdrojové prezentace.
1. Uložte upravenou cílovou prezentaci.

V níže uvedeném příkladu je snímek s indexem 0 ve zdrojové prezentaci klonován na konec cílové prezentace.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje zdrojový soubor prezentace.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován).
    with slides.Presentation() as target_presentation:
        # Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Uložte cílovou prezentaci na disk.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat na konkrétní pozici v jiné prezentaci**

Pokud potřebujete klonovat snímek z jedné prezentace a vložit jej do jiné prezentace na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro zdrojovou prezentaci (ta, která obsahuje snímek k klonování).
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro cílovou prezentaci (kam bude snímek přidán).
1. Získejte kolekci snímků z cílové prezentace.
1. Zavolejte metodu `insert_clone` na cílové [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/), předáním snímku ze zdrojové prezentace a požadovaného cílového indexu.
1. Uložte upravenou cílovou prezentaci.

V níže uvedeném příkladu je snímek s indexem 0 ve zdrojové prezentaci klonován na index 2 (pozice 3) v cílové prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje zdrojový soubor prezentace.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Vytvořte instanci třídy Presentation pro cílový PPTX (kam má být snímek klonován).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Vložte klon prvního snímku ze zdroje na index 2 v cílové prezentaci.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Uložte cílovou prezentaci na disk.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat snímek s jeho hlavním snímkem (master) do jiné prezentace**

Pokud potřebujete klonovat snímek **s jeho hlavním snímkem** z jedné prezentace a použít jej v jiné, nejprve klonujte požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Pak použijte tento cílový hlavní snímek při klonování snímku. Metoda `add_clone(Slide, MasterSlide)` očekává **hlavní snímek z cílové prezentace**, nikoli ze zdroje.

Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro zdrojovou prezentaci (ta, která obsahuje snímek k klonování).
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pro cílovou prezentaci.
1. Získejte přístup ke zdrojovému snímku k klonování a jeho hlavnímu snímku.
1. Získejte [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/) z kolekce hlavních snímků cílové prezentace.
1. Zavolejte `add_clone` na cílové [MasterSlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslidecollection/), předáním zdrojového hlavního snímku pro jeho klonování do cílové prezentace.
1. Získejte [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) z kolekce snímků cílové prezentace.
1. Zavolejte `add_clone` na cílové [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/), předáním zdrojového snímku a klonovaného cílového hlavního snímku.
1. Uložte upravenou cílovou prezentaci.

V níže uvedeném příkladu je snímek s indexem 0 ve zdrojové prezentaci klonován na konec cílové prezentace pomocí hlavního snímku klonovaného ze zdroje.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje zdrojový soubor prezentace.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Vytvořte instanci třídy Presentation pro cílovou prezentaci, kam bude snímek klonován.
    with slides.Presentation() as target_presentation:
        # Získejte první snímek ze zdrojové prezentace.
        source_slide = source_presentation.slides[0]
        # Získejte hlavní snímek, který používá první snímek.
        source_master = source_slide.layout_slide.master_slide
        # Klonujte hlavní snímek do kolekce hlavních snímků cílové prezentace.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klonujte snímek ze zdrojové prezentace na konec cílové prezentace pomocí klonovaného hlavního snímku.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Uložte cílovou prezentaci na disk.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonovat na konci v určené sekci**

S Aspose.Slides for Python via .NET můžete klonovat snímek z jedné sekce prezentace a vložit jej do jiné sekce ve stejné prezentaci. K tomu použijte metodu `add_clone(Slide, Section)` třídy [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/).

Následující ukázka v Pythonu ukazuje, jak klonovat snímek a vložit klon do určené sekce:

```py
import aspose.slides as slides

# Vytvořte novou prázdnou prezentaci.
with slides.Presentation() as presentation:
    # Přidejte prázdný snímek na základě rozvržení prvního snímku.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Přidejte eliptický tvar na nový snímek; tento snímek bude později klonován.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Přidejte další prázdný snímek na základě rozvržení prvního snímku.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Vytvořte sekci s názvem "Section2", která začíná na slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Klonujte dříve vytvořený snímek do sekce "Section2".
    presentation.slides.add_clone(slide, section)
    # Uložte prezentaci jako soubor PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zajistit shodu velikosti snímků**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti liší, Aspose.Slides automaticky nepřevzorkuje klonované tvary — jejich původní souřadnice a rozměry jsou zachovány, což může způsobit, že obsah bude nesprávně zarovnán nebo přesáhne okraje snímku.

Můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové, předtím než klonujete hlavní snímek a snímek:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Udělejte to před klonováním hlavního snímku a snímku.

## **Často kladené otázky**

**Klony zahrnují poznámky k prezentujícímu a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/python-net/presentation-notes/) po vložení.

**Jak jsou zacházeno s grafy a jejich zdrojovými daty?**

Objekt grafu, formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se souborem OLE‑embedovaným sešitem), toto propojení zůstává jako [OLE objekt](/slides/cs/python-net/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování při obnově.

**Mohu ovládat pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/python-net/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a pak přesuňte snímek do ní.