---
title: Porovnat snímky prezentace v Javě
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/java/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Porovnejte prezentace PowerPoint a OpenDocument programově pomocí Aspose.Slides pro Java. Rychle identifikujte rozdíly mezi snímky v kódu."
---
## **Přehled**

Aspose.Slides vám umožňuje porovnávat snímky, rozložení snímků a hlavní snímky pomocí metody `equals`, která je poskytována rozhraním `IBaseSlide` a třídou `BaseSlide`. Tato metoda vrací `true`, pokud jsou porovnávané snýmky totožné ve své struktuře a statickém obsahu.

## **Porovnat dva snímky**
Metoda Equals byla přidána do rozhraní [IBaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IBaseSlide) a třídy [BaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/BaseSlide). Vrací true pro snímky/rozložení a snímky/hlavní snímky, které jsou identické ve své struktuře a statickém obsahu. 

Dva snímky jsou stejné, pokud jsou všechny tvary, styly, texty, animace a ostatní nastavení apod. stejné. Porovnání nebere v úvahu hodnoty jedinečných identifikátorů, např. SlideId, ani dynamický obsah, např. aktuální datum v zástupci data.

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

## **FAQ**

**Má skrytý snímek vliv na porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getHidden--) je vlastnost na úrovni prezentace/přehrávání, nikoli vizuální obsah. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotná skutečnost, že je snímek skrytý, nedělá snímky odlišnými.

**Berou se hypertextové odkazy a jejich parametry v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, je to obvykle považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, budou brány v úvahu jeho obsah?**

Ne. Porovnání se provádí na základě samotných snímků. Externí datové zdroje se při porovnání obecně nečtou; berou se v úvahu pouze to, co je přítomno ve struktuře a statickém stavu snímku.