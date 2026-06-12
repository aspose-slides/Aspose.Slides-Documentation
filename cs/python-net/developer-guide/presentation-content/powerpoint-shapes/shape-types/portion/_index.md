---
title: Správa textových úseků v prezentacích pomocí Pythonu
linktitle: Textový úsek
type: docs
weight: 70
url: /cs/python-net/portion/
keywords:
- textový úsek
- textová část
- souřadnice textu
- pozice textu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat textové úseky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET, což zvyšuje výkon a možnosti přizpůsobení."
---
## **Úvod**

Textový úsek představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat polohu textového fragmentu, použít formátování jen na část odstavce nebo řídit chování textu na podrobnější úrovni.

## **Získání souřadnic textových úseků**

Metoda [get_coordinates](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/get_coordinates/) byla přidána do třídy [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/), která umožňuje získat souřadnice textových úseků:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **Často kladené otázky**

**Mohu aplikovat hypertextový odkaz jen na část textu v jediném odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/python-net/manage-hyperlinks/) k jednotlivému úseku; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědictví stylů: co přepisuje Portion a co je převzato z Paragraph/TextFrame?**

Vlastnosti na úrovni Portion mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/), engine ji získá z [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/); pokud není nastavena ani tam, získá se z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) nebo ze stylu [theme](https://reference.aspose.com/slides/cs/python-net/aspose.slides.theme/theme/).

**Co se stane, pokud je písmo určené pro Portion na cílovém počítači/serveru chybějící?**

[Pravidla náhrady písem](/slides/cs/python-net/font-selection-sequence/) se použijí. Text se může přeuspořádat: mohou se změnit metriky, dělení slov a šířka, což má význam pro přesné umístění.

**Mohu nastavit průhlednost nebo gradient výplně textu specifické pro Portion nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.