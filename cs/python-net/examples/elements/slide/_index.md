---
title: Snímek
type: docs
weight: 10
url: /cs/python-net/examples/elements/slide/
keywords:
- snímek
- přidat snímek
- přístup ke snímku
- index snímku
- klonovat snímek
- přeskupit snímky
- odstranit snímek
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte snímky v Pythonu pomocí Aspose.Slides: vytvářejte, klonujte, přeskupujte, skrývejte, nastavujte pozadí a velikost, aplikujte přechody a exportujte pro PowerPoint a OpenDocument."
---
Tento článek poskytuje sérii příkladů, které ukazují, jak pracovat se snímky pomocí **Aspose.Slides for Python via .NET**. Naučíte se, jak přidávat, přistupovat, klonovat, měnit pořadí a odstraňovat snímky pomocí třídy `Presentation`.

Každý příklad níže obsahuje stručné vysvětlení následované ukázkou kódu v Pythonu.

## **Přidat snímek**

Chcete-li přidat nový snímek, musíte nejprve vybrat rozložení. V tomto příkladu používáme rozložení `Blank` a přidáme prázdný snímek do prezentace.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Každý snímek je založen na rozložení, které samo vychází z hlavního snímku.
        # Použijte rozložení Blank k vytvoření nového snímku.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Přidejte nový prázdný snímek pomocí vybraného rozložení.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Každé rozložení snímku vychází z hlavního snímku, který určuje celkový design a strukturu zástupných symbolů. Obrázek níže ilustruje, jak jsou hlavní snímky a jejich související rozložení v PowerPointu uspořádány.

![Vztah hlavního snímku a rozložení](master-layout-slide.png)

## **Přístup ke snímkům podle indexu**

Ke snímkům můžete přistupovat pomocí jejich indexu. To je užitečné pro iteraci nebo úpravu konkrétních snímků.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Přístup ke snímku podle indexu.
        first_slide = presentation.slides[0]
```

## **Klonovat snímek**

Tento příklad ukazuje, jak klonovat existující snímek. Klonovaný snímek je automaticky přidán na konec kolekce snímků.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Zkopírujte snímek; bude přidán na konec prezentace.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Přeskupit snímky**

Pořadí snímků můžete změnit přesunutím některého na nový index. V tomto případě přesuneme snímek na první pozici.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Přesuňte snímek na první pozici (ostatní se posunou dolů).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit snímek**

Pro odstranění snímku jej jednoduše odkažte a zavolejte `remove`. Tento příklad odstraňuje první snímek.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Odeberte snímek.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```