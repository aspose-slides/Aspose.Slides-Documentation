---
title: Přidání obdélníků do prezentací v Pythonu prostřednictvím Java
linktitle: Obdélník
type: docs
weight: 80
url: /cs/python-java/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zvýrazněte své prezentace PowerPoint přidáním obdélníků pomocí Aspose.Slides pro Python přes Java - snadno navrhujte a upravujte tvary programově."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat do snímků PowerPointu tvary obdélníku. Popisuje vytvoření jednoduchého obdélníku, vytvoření formátovaného obdélníku a uložení aktualizované prezentace jako souboru PPTX.

Také uvidíte, jak použít základní formátování obdélníku, jako je plná barva výplně, barva čáry a šířka čáry. Navíc sekce FAQ článku odkazuje na související úlohy s obdélníky, včetně zaoblených rohů, výplní obrázky, vizuálních efektů, hypertextových odkazů, uzamčení tvaru, možností exportu a efektivních vlastností.

## **Přidání obdélníku do snímku**

Chcete-li přidat jednoduchý obdélník do vybraného snímku prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu obdélník pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte tvar obdélníku.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Zapište soubor PPTX na disk.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidání formátovaného obdélníku do snímku**

Chcete-li přidat formátovaný obdélník do snímku, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu obdélník pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Nastavte [fill type](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) obdélníku na solid.
- Nastavte barvu obdélníku pomocí metody [setColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/colorformat/#setColor) na objektu [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) přidruženém k objektu [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/).
- Nastavte barvu obrysu obdélníku.
- Nastavte šířku obrysu obdélníku.
- Zapište upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte tvar obdélníku.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Naformátujte výplň obdélníku.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Naformátujte obrys obdélníku.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Zapište soubor PPTX na disk.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jak přidat obdélník se zaoblenými rohy?**

Použijte typ tvaru s zaoblenými rohy [shape type](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/) a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí geometrických úprav.

**Jak vyplnit obdélník obrázkem (texturou)?**

Vyberte typ výplně obrázkem [fill type](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/), zadejte zdroj obrázku a nakonfigurujte režimy [stretching/tiling modes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/python-java/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu přeměnit obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/python-java/manage-hyperlinks/) pro kliknutí na tvar (přechod na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu chránit obdélník před přesunem a změnami?**

[Use shape locks](/slides/cs/python-java/applying-protection-to-presentation/): můžete zakázat přesun, změnu velikosti, výběr nebo úpravy textu, aby byl zachován rozvržení.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) na obrázek se specifickou velikostí/měřítkem nebo [export it as SVG](/slides/cs/python-java/create-shape-thumbnails/) pro vektorové použití.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníku s ohledem na téma a dědičnost?**

[Use the shape’s effective properties](/slides/cs/python-java/shape-effective-properties/): API vrací vypočtené hodnoty, které zahrnují styly tématu, rozvržení a lokální nastavení, což zjednodušuje analýzu formátování.