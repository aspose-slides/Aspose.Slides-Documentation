---
title: Získání ohraničení textového úseku z prezentací v Pythonu
linktitle: Ohraničení úseku
type: docs
weight: 47
url: /cs/python-net/portion-bounds/
keywords:
- ohraničení textového úseku
- textový úsek
- textová část
- souřadnice textu
- pozice textu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak získat ohraničení textového úseku v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Textový úsek představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat ohraničení textového fragmentu, aplikovat formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník úseku pomocí [Portion.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/get_rect/). Také ukazuje, jak získat souřadnice začátku úseku pomocí [Portion.get_coordinates](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/get_coordinates/). Navíc zdůrazňuje běžné scénáře související s úseky, jako je aplikace hypertextového odkazu na jediný textový fragment, pochopení, jak se formátování řeší přes úsek, odstavec, textový rámeček a dědičnost motivu, a řešení situací, kdy požadovaný font není k dispozici.

## **Získání ohraničení textového úseku**

Použijte [Portion.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/get_rect/) k získání ohraničujícího obdélníku textového úseku:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Získání souřadnic textového úseku**

Použijte [Portion.get_coordinates](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/get_coordinates/) k získání souřadnic začátku textového úseku:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **Často kladené otázky**

**Mohu použít hypertextový odkaz jen na část textu v jednom odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/python-net/manage-hyperlinks/) jednotlivému úseku; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylu: co úsek přepisuje a co se převzato z odstavce nebo textového rámce?**

Vlastnosti na úrovni úseku mají nejvyšší přednost. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/), Aspose.Slides ji převzme z [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/). Pokud není nastavena ani tam, použije Aspose.Slides styl z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) nebo [theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/theme/).

**Co se stane, pokud je font určený pro úsek na cílovém počítači nebo serveru nedostupný?**

[Pravidla náhrady fontu](/slides/cs/python-net/font-selection-sequence/) se uplatní. Text se může přeuspořádat: metriky, dělení slov a šířka se mohou změnit, což má vliv na přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifický pro úsek nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.