---
title: Přidání trendových čar do diagramů v prezentaci v C++
linktitle: Trendová čára
type: docs
url: /cs/cpp/trend-line/
keywords:
- diagram
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- trendová čára klouzavého průměru
- polynomiální trendová čára
- mocninná trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte trendové čáry v diagramách PowerPointu pomocí Aspose.Slides pro C++ — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat trendové čáry do diagramů v prezentaci. Ukazuje, jak vytvořit diagram, přidat trendové čáry do sérií diagramu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomiální a mocninné.  

Také popisuje, jak do diagramu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátkou sekci FAQ o hodnotách projekce trendové čáry dopředu a dozadu a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při vykreslování diagramů jako obrázků.

## **Přidání trendové čáry**
Aspose.Slides pro C++ poskytuje jednoduché API pro správu různých trendových čar diagramu:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte referenci snímku podle jeho indexu.
3. Přidejte diagram s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá ChartType.ClusteredColumn).
4. Přidání exponenciální trendové čáry pro sérii diagramu 1.
5. Přidání lineární trendové čáry pro sérii diagramu 1.
6. Přidání logaritmické trendové čáry pro sérii diagramu 2.
7. Přidání trendové čáry klouzavého průměru pro sérii diagramu 2.
8. Přidání polynomiální trendové čáry pro sérii diagramu 3.
9. Přidání mocninné trendové čáry pro sérii diagramu 3.
10. Zapište upravenou prezentaci do souboru PPTX.

Následující kód slouží k vytvoření diagramu s trendovými čarami.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Přidání vlastní čáry**
Aspose.Slides pro C++ poskytuje jednoduché API pro přidání vlastních čar do diagramu. Pro přidání jednoduché rovné čáry do vybraného snímku prezentace postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation
- Získejte referenci snímku pomocí jeho Indexu
- Vytvořte nový diagram pomocí metody AddChart, kterou poskytuje objekt Shapes
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, kterou poskytuje objekt Shapes
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

Následující kód slouží k vytvoření diagramu s vlastními čarami.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Co znamená 'forward' a 'backward' pro trendovou čáru?**

Jedná se o délky trendové čáry promítnuté dopředu/dozadu: pro rozptylové (XY) diagramy — v jednotkách osy; pro nediskrétní diagramy — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane trendová čára zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) a vykresluje diagramy jako obrázky; trendové čáry jako součást diagramu jsou během těchto operací zachovány. K dispozici je také metoda pro [export obrázku diagramu](/slides/cs/cpp/create-shape-thumbnails/).