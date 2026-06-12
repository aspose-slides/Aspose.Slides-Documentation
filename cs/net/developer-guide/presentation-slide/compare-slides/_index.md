---
title: Porovnání snímků prezentace v .NET
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/net/compare-slides/
keywords:
- porovnání snímků
- srovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Porovnejte programově prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Rychle zjistěte rozdíly mezi snímky v kódu."
---
## **Přehled**

Aspose.Slides vám umožňuje porovnávat snímky, rozložení snímků a hlavní snímky pomocí metody `Equals`, kterou poskytuje rozhraní `IBaseSlide` a třída `BaseSlide`. Tato metoda vrací `true`, pokud jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnat dva snímky**

Metoda Equals byla přidána do rozhraní [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide) a třídy [BaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslide). Vrací `true` pro snímky/rozložení a snímky/hlavní snímky, které jsou identické ve své struktuře a statickém obsahu.

Dva snímky jsou si rovny, pokud jsou shodné všechny tvary, styly, texty, animace a další nastavení atd. Porovnání nebere v úvahu jedinečné identifikátory, například SlideId, ani dynamický obsah, například aktuální datum v zástupci data.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **Často kladené otázky**

**Má skrytý snímek vliv na porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/) je vlastnost na úrovni prezentace/přehrávání, nikoli vizuálního obsahu. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotná skutečnost, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Berou se hypertextové odkazy a jejich parametry v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, je to obvykle považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, bude obsah tohoto souboru brán v úvahu?**

Ne. Porovnání se provádí na základě samotných snímků. Externí zdroje dat se obecně při porovnání nečtou; berou se v úvahu pouze to, co je přítomno ve struktuře a statickém stavu snímku.