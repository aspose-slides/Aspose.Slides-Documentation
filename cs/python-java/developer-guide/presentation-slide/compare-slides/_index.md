---
title: Porovnat snímky prezentace v Pythonu
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/python-java/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Programově porovnejte prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java. Rychle identifikujte rozdíly mezi snímky v kódu."
---
## **Přehled**

Aspose.Slides vám umožňuje porovnávat snímky, uspořádací snímky a hlavní snímky pomocí metody [equals](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#equals) poskytované třídou [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/). Tato metoda vrací `True`, když jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnat dva snímky**

Metoda [equals](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#equals) ve třídě [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/) vrací `True` pro snímky, uspořádací snímky i hlavní snímky, které jsou identické ve své struktuře a statickém obsahu.

Dva snímky jsou stejné, pokud jsou všechny jejich tvary, styly, text, animace i další nastavení shodné. Při porovnávání se neberou v úvahu jedinečné identifikátory, jako jsou ID snímků, ani dynamický obsah, například aktuální datum v zástupci data.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Často kladené otázky**

**Má skrytý snímek vliv na porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getHidden) je vlastnost na úrovni prezentace/přehrávání, nikoli vizuálního obsahu. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotný fakt, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Berou se hypertextové odkazy a jejich parametry v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, je to obvykle považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, budou brány v úvahu jeho obsah?**

Ne. Porovnání se provádí na základě samotných snímků. Externí zdroje dat se obecně při porovnávání nečtou; zohledněno je pouze to, co je přítomno ve struktuře a statickém stavu snímku.