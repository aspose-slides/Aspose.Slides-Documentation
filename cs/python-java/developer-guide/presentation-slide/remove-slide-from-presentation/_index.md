---
title: Odstranění snímků z prezentací v Pythonu
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/python-java/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužívaný snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše odstraňte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java. Získejte přehledné ukázky kódu a zefektivněte svůj pracovní postup."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej smazat. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) , která zapouzdřuje [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) , což je úložiště všech snímků v prezentaci. Pomocí reference nebo indexu k známému objektu [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) můžete určit snímek, který chcete odebrat. 

## **Odstranění snímku podle reference**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek, který chcete odstranit, pomocí jeho ID nebo indexu.
1. Odeberte referencovaný snímek z prezentace.
1. Uložte upravenou prezentaci. 

Tento Python kód vám ukazuje, jak odstranit snímek pomocí jeho reference:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("demo.pptx")
try:
    # Získejte snímek pomocí jeho indexu v kolekci snímků.
    slide = presentation.getSlides().get_Item(0)

    # Odeberte snímek pomocí jeho reference.
    presentation.getSlides().remove(slide)

    # Uložte upravenou prezentaci.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odstranění snímku podle indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
1. Odeberte snímek z prezentace pomocí jeho indexové pozice.
1. Uložte upravenou prezentaci. 

Tento Python kód vám ukazuje, jak odstranit snímek pomocí jeho indexu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("demo.pptx")
try:
    # Odstraňte snímek pomocí jeho indexu.
    presentation.getSlides().removeAt(0)

    # Uložte upravenou prezentaci.
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odstranění nepoužívaných snímků rozvržení**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) (ze třídy [Compress](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/) ), která vám umožní smazat nechtěné a nepoužívané snímky rozvržení. Tento Python kód vám ukazuje, jak odstranit snímek rozvržení z PowerPoint prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odstranění nepoužívaných hlavních snímků**

Aspose.Slides poskytuje metodu [removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/#removeUnusedMasterSlides) (ze třídy [Compress](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compress/) ), která vám umožní smazat nechtěné a nepoužívané hlavní snímky. Tento Python kód vám ukazuje, jak odstranit hlavní snímek z PowerPoint prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Časté dotazy**

**Co se stane s indexy snímků po smazání snímku?**

Po smazání se [kolekce](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) znovu indexuje: každý následující snímek se posune o jednu pozici doleva, takže předchozí čísla indexů jsou zastaralá. Pokud potřebujete stabilní referenci, použijte trvalé ID každého snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index představuje pozici snímku a změní se, když jsou snímky přidány nebo odebrány. ID snímku je trvalý identifikátor a nemění se, když jsou jiné snímky smazány.

**Jak smazání snímku ovlivní sekce snímků?**

Pokud snímek patřil do sekce, tato sekce bude jednoduše obsahovat o jeden snímek méně. Struktura sekcí zůstává; pokud sekce zůstane prázdná, můžete ji [odstranit nebo přeuspořádat](/slides/cs/python-java/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými ke snímku, když je smazán?**

[Notes](/slides/cs/python-java/presentation-notes/) a [comments](/slides/cs/python-java/presentation-comments/) jsou vázány na konkrétní snímek a jsou s ním odstraněny. Obsah na ostatních snímcích zůstává nedotčen.

**Jak se liší mazání snímků od čištění nepoužívaných rozvržení/masterů?**

Mazání odebere konkrétní běžné snímky z prezentace. Čištění nepoužívaných rozvržení/masterů odstraní rozvržení nebo hlavní snímky, na které nic neodkazuje, což zmenší velikost souboru, aniž by se změnil obsah zbývajících snímků. Tyto akce jsou doplňkové: obvykle se nejprve maže, pak se provádí čištění.