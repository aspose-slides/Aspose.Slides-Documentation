---
title: Získání ohraničení textového úseku z prezentací v Pythonu přes Java
linktitle: Ohraničení úseku
type: docs
weight: 47
url: /cs/python-java/portion-bounds/
keywords:
- ohraničení textového úseku
- textový úsek
- část textu
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak získat ohraničení textového úseku v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Textový úsek představuje konkrétní fragment textu v odstavci a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat ohraničení textového fragmentu, použít formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník úseku pomocí [Portion.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getRect). Také ukazuje, jak získat souřadnice začátku úseku pomocí [Portion.getCoordinates](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getCoordinates). Dále zdůrazňuje běžné scénáře související s úseky, jako je aplikace hypertextového odkazu na jednotlivý textový fragment, pochopení, jak je formátování řešeno přes úsek, odstavec, textový rámec a dědičnost motivu, a řešení případů, kdy zadané písmo není k dispozici.

## **Získání ohraničení textového úseku**

Použijte [Portion.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getRect) k získání ohraničujícího obdélníku textového úseku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Získání souřadnic textového úseku**

Použijte [Portion.getCoordinates](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getCoordinates) k získání souřadnic začátku textového úseku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu použít hypertextový odkaz pouze na část textu v jediném odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/python-java/manage-hyperlinks/) jednotlivému úseku; pouze tento fragment bude klikací, nikoli celý odstavec.

**Jak funguje dědičnost stylů: co úsek přepíše a co je převzato z odstavce nebo textového rámce?**

Vlastnosti na úrovni úseku mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/), Aspose.Slides ji převezme z [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/). Pokud není nastavena ani tam, Aspose.Slides použije styl z [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) nebo [theme](https://reference.aspose.com/slides/cs/python-java/aspose.slides/theme/).

**Co se stane, pokud je písmo určené pro úsek na cílovém počítači nebo serveru chybějící?**

[Pravidla pro substituci fontů](/slides/cs/python-java/font-selection-sequence/) se použijí. Text se může přeuspořádat: metriky, dělení slov a šířka se mohou změnit, což má vliv na přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifické pro úsek nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.