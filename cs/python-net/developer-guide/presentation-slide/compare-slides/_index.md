---
title: Porovnání snímků prezentace v Pythonu
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/python-net/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Programově porovnejte prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET. Rychle identifikujte rozdíly mezi snímky v kódu."
---
## **Přehled**

Aspose.Slides umožňuje porovnávat snímky, snímky rozvržení a hlavní snímky pomocí metody `equals`, kterou poskytuje třída `BaseSlide`. Tato metoda vrací `True`, pokud jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnání dvou snímků**
Metoda `equals` byla přidána do třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/). Vrací true pro snímky/rozvržení a snímky/hlavní snímky, které jsou identické v jejich struktuře a statickém obsahu.

Dva snímky jsou shodné, pokud mají všechny tvary, styly, texty, animace a další nastavení. Porovnání nebere v úvahu jedinečné identifikátory, např. SlideId, ani dynamický obsah, např. aktuální datum v zástupci data.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **Často kladené otázky**

**Ovlivňuje skrytí snímku porovnání samotných snímků?**

[Skrytý stav](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/) je vlastností úrovně prezentace/přehrávání, nikoli vizuálního obsahu. Shodnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotný fakt, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Jsou hypertextové odkazy a jejich parametry brány v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, obvykle je to považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, bude obsah tohoto souboru brán v úvahu?**

Ne. Porovnání se provádí na základě samotných snímků. Externí datové zdroje se obecně při porovnávání nečtou; bere se v úvahu pouze to, co je obsaženo ve struktuře a statickém stavu snímku.