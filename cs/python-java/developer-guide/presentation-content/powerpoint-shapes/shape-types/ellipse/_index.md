---
title: Přidání elips do prezentací v Pythonu přes Java
linktitle: Elipsa
type: docs
weight: 30
url: /cs/python-java/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- nakreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se vytvářet, formátovat a manipulovat s eliptickými tvary v Aspose.Slides pro Python přes Java v prezentacích PPT i PPTX – včetně ukázek kódu v Pythonu."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat eliptické tvary do snímků PowerPointu. Popisuje vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Také se dotýká souvisejících otázek, jako je práce s umístěním a velikostí elipsy, řízení pořadí vrstvení a použití animačních efektů.

## **Vytvoření elipsy**

Chcete‑li přidat jednoduchou elipsu na vybraný snímek prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Přidejte elipsu pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Zapište upravenou prezentaci jako soubor PPTX.

Následující příklad přidává elipsu na první snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidat tvar elipsy.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Zapsat soubor PPTX na disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vytvoření formátované elipsy**

Chcete‑li přidat formátovanou elipsu na snímek, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na snímek podle jeho indexu.
- Přidejte elipsu pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape) objektu [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/).
- Nastavte typ výplně elipsy na pevnou.
- Nastavte barvu výplně elipsy pomocí [getSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getSolidFillColor) na objektu [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) spojeném s objektem [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/).
- Nastavte barvu obrysu elipsy.
- Nastavte šířku obrysu elipsy.
- Zapište upravenou prezentaci jako soubor PPTX.

Následující příklad přidává formátovanou elipsu na první snímek prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidat tvar elipsy.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Naformátovat výplň elipsy.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Naformátovat obrys elipsy.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Zapsat soubor PPTX na disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jak mohu nastavit přesnou polohu a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a rozměry jsou obvykle zadávány **v bodech**. Pro předvídatelné výsledky založte výpočty na velikosti snímku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládat pořadí vrstvení)?**

Upravte pořadí vykreslování objektu jeho přesunutím do popředí nebo do pozadí. Tím umožníte, aby elipsa překrývala jiné objekty nebo odhalila ty pod ní.

**Jak animuji zobrazení nebo zdůraznění elipsy?**

[Použít](/slides/cs/python-java/shape-animation/) vstupní, zdůrazňovací nebo výstupní efekty na tvar a nakonfigurujte spouštěče a časování, abyste určili, kdy a jak se animace přehrává.