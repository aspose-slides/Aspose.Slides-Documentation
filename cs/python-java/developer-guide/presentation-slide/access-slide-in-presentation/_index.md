---
title: Přístup k snímkům prezentace v Pythonu
linktitle: Přístup ke snímku
type: docs
weight: 20
url: /cs/python-java/access-slide-in-presentation/
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
description: "Naučte se, jak pomocí Aspose.Slides pro Python přes Java přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument. Zvyšte produktivitu pomocí ukázek kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přistupovat k snímkům v prezentaci a spravovat je. Ukazuje, jak načíst snímky podle jejich nulového indexu ze sbírky snímků a jak přistupovat k snímku podle jeho jedinečného ID pomocí metody [getSlideById](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlideById).

Také se naučíte, jak změnit pozici snímku pomocí metody [setSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setSlideNumber) a jak definovat počáteční číslo snímku pro prezentaci pomocí metody [setFirstSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#setFirstSlideNumber). Příklady ukazují načtení prezentace, získání odkazů na snímky, aktualizaci pořadí nebo číslování snímků a uložení upravené prezentace.

## **Přístup k snímku podle indexu**

Všechny snímky v prezentaci jsou uspořádány číselně podle pozice snímku počínaje 0. První snímek je přístupný přes index 0; druhý snímek je přístupný přes index 1; atd.

Třída [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) představující soubor prezentace zpřístupňuje všechny snímky jako kolekci [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) (kolekci objektů [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/)). Tento Python kód ukazuje, jak přistupovat k snímku podle jeho indexu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Vytvořte objekt Presentation, který reprezentuje soubor prezentace.
presentation = Presentation("demo.pptx")
try:
    # Přístup k snímku pomocí jeho indexu.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Přístup k snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. K cílení na toto ID můžete použít metodu [getSlideById](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlideById) (poskytnutou třídou [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/)). Tento Python kód ukazuje, jak zadat platné ID snímku a přistoupit k tomuto snímku pomocí metody [getSlideById](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlideById):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("demo.pptx")
try:
    # Získejte ID snímku.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Přístup ke snímku přes jeho ID.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Změna pozice snímku**

Aspose.Slides umožňuje změnit pozici snímku. Například můžete určit, že první snímek se má stát druhým snímkem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek (kterého pozici chcete změnit) podle jeho indexu.
1. Nastavte novou pozici snímku pomocí metody [setSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#setSlideNumber).
1. Uložte upravenou prezentaci.

Tento Python kód demonstruje operaci, při které je snímek na pozici 1 přesunut na pozici 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("Presentation.pptx")
try:
    # Získejte snímek, jehož pozice bude změněna.
    slide = presentation.getSlides().get_Item(0)

    # Nastavte novou pozici snímku.
    slide.setSlideNumber(2)

    # Uložte upravenou prezentaci.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

První snímek se stal druhým; druhý snímek se stal prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky upraveny.

## **Nastavení čísla snímku**

Pomocí metody [setFirstSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#setFirstSlideNumber) (poskytnuté třídou [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/)) můžete nastavit nové číslo pro první snímek v prezentaci. Tato operace způsobí, že ostatní čísla snímků jsou přepočítána.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte číslo snímku.
1. Nastavte číslo snímku.
1. Uložte upravenou prezentaci.

Tento Python kód ukazuje operaci, při které je číslo prvního snímku nastaveno na 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("HelloWorld.pptx")
try:
    # Získejte číslo snímku.
    first_slide_number = presentation.getFirstSlideNumber()

    # Nastavte číslo snímku.
    presentation.setFirstSlideNumber(10)

    # Uložte upravenou prezentaci.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pokud chcete přeskočit první snímek, můžete číslování začít od druhého snímku (a číslo prvního snímku skryt) takto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    #     Nastavte číslo pro první snímek prezentace.
    presentation.setFirstSlideNumber(0)

    #     Zobrazte čísla snímků pro všechny snímky.
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    #     Skryjte číslo snímku pro první snímek.
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    #     Uložte upravenou prezentaci.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu ve sbírce?**

Číslo zobrazené na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah řídí nastavení [první číslo snímku](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#setFirstSlideNumber) prezentace.

**Ovlivňují skryté snímky indexování?**

Ano. Skrytý snímek zůstává ve sbírce a je započítán do indexování; „skrytý“ se vztahuje na zobrazení, nikoli na jeho pozici ve sbírce.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí snímků a jsou přepočítány při vložení, odstranění a přesunu.