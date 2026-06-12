---
title: Porovnání snímků prezentace na Androidu
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/androidjava/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Porovnejte programově prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro Android. Rychle identifikujte rozdíly snímků v kódu Java."
---
## **Přehled**

Aspose.Slides umožňuje porovnávat snímky, snímky rozvržení a hlavní snímky pomocí metody `equals`, která je k dispozici v rozhraní `IBaseSlide` a ve třídě `BaseSlide`. Tato metoda vrací `true`, pokud jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnání dvou snímků**
Metoda Equals byla přidána do rozhraní [IBaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBaseSlide) a třídy [BaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/BaseSlide). Vrací true pro snímky/rozvržení a snímky/hlavní snímky, které jsou identické ve své struktuře a statickém obsahu.

Dva snímky jsou stejné, pokud jsou stejné všechny tvary, styly, texty, animace a další nastavení apod. Porovnání nebere v úvahu jedinečné identifikátory, například SlideId, ani dynamický obsah, například aktuální datum v Date Placeholder.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje skutečnost, že je snímek skrytý, porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#getHidden--) je vlastnost úrovně prezentace / přehrávání, nikoli vizuálního obsahu. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotná skutečnost, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Berou se hypertextové odkazy a jejich parametry v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, je to obvykle považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, bude obsah tohoto souboru zohledněn?**

Ne. Porovnání se provádí na základě samotných snímků. Vnější datové zdroje se při porovnávání obecně nečtou; berou se v úvahu pouze to, co je přítomno ve struktuě a statickém stavu snímku.