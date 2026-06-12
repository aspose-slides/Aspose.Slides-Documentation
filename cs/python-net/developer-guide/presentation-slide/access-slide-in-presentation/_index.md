---
title: Přístup ke snímkům v prezentacích pomocí Pythonu
linktitle: Přístup ke snímku
type: docs
weight: 20
url: /cs/python-net/access-slide-in-presentation/
keywords:
- přístup ke snímku
- index snímku
- ID snímku
- pozice snímku
- změna pozice
- vlastnosti snímku
- číslo snímku
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Zvyšte produktivitu pomocí ukázek kódu."
---
## **Přehled**

Tento článek vysvětluje, jak přistupovat ke konkrétním snímkům v prezentaci PowerPoint pomocí Aspose.Slides pro Python. Ukazuje, jak otevřít prezentaci, odkazovat na snímky podle indexu nebo jedinečného ID a načíst základní informace o snímcích potřebné pro navigaci v souboru. Pomocí těchto technik můžete spolehlivě najít přesně ten snímek, který chcete prozkoumat nebo zpracovat.

## **Přístup ke snímku podle indexu**

Snímky v prezentaci jsou indexovány podle pozice počínaje 0. První snímek má index 0, druhý snímek má index 1 atd.

Třída [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) (která představuje soubor prezentace) zpřístupňuje snímky prostřednictvím [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) objektů typu [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/).

Následující kód v Pythonu ukazuje, jak přistupovat ke snímku podle jeho indexu:

```python
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    # Získejte snímek podle jeho indexu.
    slide = presentation.slides[0]
```

## **Přístup ke snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. K tomuto ID můžete přistupovat pomocí metody [get_slide_by_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_slide_by_id/) (která je součástí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ) .

Následující kód v Pythonu ukazuje, jak zadat platné ID snímku a získat tento snímek pomocí metody [get_slide_by_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_slide_by_id/) :

```python
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    # Získejte ID snímku.
    id = presentation.slides[0].slide_id
    # Přistupte ke snímku pomocí jeho ID.
    slide = presentation.get_slide_by_id(id)
```

## **Změna pozice snímku**

Aspose.Slides umožňuje změnit pozici snímku. Například můžete první snímek udělat druhým.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Získejte odkaz na snímek, jehož pozici chcete změnit, podle jeho indexu.
3. Nastavte novou pozici snímku pomocí vlastnosti [slide_number](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/slide_number/) .
4. Uložte upravenou prezentaci.

Následující kód v Pythonu přesunuje snímek z pozice 1 na pozici 2:

```python
import aspose.slides as slides

# Vytvořte instanci objektu Presentation, který představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    # Získejte snímek, jehož pozice bude změněna.
    slide = presentation.slides[0]
    # Nastavte novou pozici pro snímek.
    slide.slide_number = 2
    # Uložte upravenou prezentaci.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

První snímek se stane druhým; druhý snímek se stane prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky upraveny.

## **Nastavení čísla snímku**

Pomocí vlastnosti [first_slide_number](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/first_slide_number/) (která je součástí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ) můžete určit nové číslo pro první snímek v prezentaci. Tato operace způsobí přepočítání čísel ostatních snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Nastavte číslo snímku.
3. Uložte upravenou prezentaci.

Následující kód v Pythonu demonstruje operaci, kdy je první číslo snímku nastaveno na 10:

```python
import aspose.slides as slides

# Vytvořte instanci objektu Presentation, který představuje soubor prezentace.
with slides.Presentation("sample.pptx") as presentation:
    # Nastavte číslo snímku.
    presentation.first_slide_number = 10
    # Uložte upravenou prezentaci.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Pokud chcete přeskočit první snímek, můžete číslování začít od druhého snímku (a skrýt číslo na prvním snímku) takto:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Nastavte číslo pro první snímek v prezentaci.
    presentation.first_slide_number = 0

    # Zobrazte čísla snímků pro všechny snímky.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Skryjte číslo snímku na prvním snímku.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Uložte upravenou prezentaci.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu v kolekci?**

Číslo zobrazené na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah je řízen nastavením [first slide number](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/first_slide_number/) prezentace.

**Ovlivňují skryté snímky indexování?**

Ano. Skrytý snímek zůstává v kolekci a je počítán při indexování; „skrytý“ se vztahuje k zobrazení, ne k jeho pozici v kolekci.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí snímků a jsou přepočítány při vkládání, mazání a přesouvání operacích.