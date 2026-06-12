---
title: Porovnat snímky prezentace v C++
linktitle: Porovnat snímky
type: docs
weight: 50
url: /cs/cpp/compare-slides/
keywords:
- porovnat snímky
- porovnání snímků
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Programově porovnejte prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Rychle identifikujte rozdíly snímků v kódu."
---
## **Přehled**

Aspose.Slides vám umožňuje porovnávat snímky, rozložení snímků a hlavní snímky pomocí metody `Equals`, která je k dispozici v rozhraní `IBaseSlide` a třídě `BaseSlide`. Tato metoda vrací `true`, když jsou porovnávané snímky identické ve své struktuře a statickém obsahu.

## **Porovnat dva snímky**
Metoda Equals byla přidána do rozhraní IBaseSlide a třídy BaseSlide. Vrací true pro snímky / rozložení snímků / hlavní snímky, které jsou identické ve své struktuře a statickém obsahu.

Dva snímky jsou stejné, pokud mají všechny tvary, styly, texty, animace a ostatní nastavení, atd. Porovnání nezohledňuje jedinečné identifikátory, např. SlideId, ani dynamický obsah, např. aktuální datum v zástupci Data.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **Často kladené otázky**

**Ovlivňuje skrytí snímku porovnání samotných snímků?**

[Hidden status](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/get_hidden/) je vlastnost úrovně prezentace/přehrávání, nikoli vizuálního obsahu. Rovnost dvou konkrétních snímků je určena jejich strukturou a statickým obsahem; samotný fakt, že je snímek skrytý, neznamená, že jsou snímky odlišné.

**Jsou hypertextové odkazy a jejich parametry brány v úvahu?**

Ano. Odkazy jsou součástí statického obsahu snímku. Pokud se liší URL nebo akce hypertextového odkazu, je to obvykle považováno za rozdíl ve statickém obsahu.

**Pokud graf odkazuje na externí soubor Excel, bude obsah tohoto souboru brán v úvahu?**

Ne. Porovnání se provádí na základě samotných snímků. Vnější datové zdroje se při porovnání obecně nečtou; bere se v úvahu pouze to, co je přítomné ve struktuře a statickém stavu snímku.