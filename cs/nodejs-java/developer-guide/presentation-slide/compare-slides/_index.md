---
title: Porovnat snímky prezentace v JavaScriptu
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/nodejs-java/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Programově porovnávejte prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Rychle identifikujte rozdíly mezi snímky v kódu."
---
## **Přehled**

Aspose.Slides vám umožňuje porovnávat snímky, rozložení snímků a hlavní snímky pomocí metody `equals`, která je součástí třídy `BaseSlide`. Tato metoda vrací `true`, pokud jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnat dva snímky**

Metoda Equals byla přidána do třídy [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BaseSlide) a třídy [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BaseSlide). Vrací true pro snímky/rozložení a snímky/hlavní snímky, které jsou identické ve své struktuře a statickém obsahu.

Dva snímky jsou stejné, pokud jsou shodné všechny tvary, styly, texty, animace a další nastavení atd. Porovnání nezohledňuje jedinečné identifikátory, např. SlideId, ani dynamický obsah, např. aktuální datum v zástupci Data.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

**Má skrytý snímek vliv na porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/gethidden/) je vlastnost na úrovni prezentace/přehrávání, nikoli vizuální obsah. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotná skutečnost, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Jsou hypertextové odkazy a jejich parametry zohledněny?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, obvykle se to považuje za rozdíl ve statickém obsahu.

**Pokud se graf odkazuje na externí soubor Excel, bude obsah tohoto souboru zohledněn?**

Ne. Porovnání se provádí na základě samotných snímků. Externí datové zdroje se obecně při porovnávání nečtou; zohledněno je pouze to, co je obsaženo ve struktuře a statickém stavu snímku.