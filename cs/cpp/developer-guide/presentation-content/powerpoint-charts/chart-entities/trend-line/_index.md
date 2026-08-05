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
- polynomická trendová čára
- mocninná trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte trendové čáry v diagramech PowerPointu pomocí Aspose.Slides pro C++ — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do diagramů prezentace trendové čáry. Ukazuje, jak vytvořit diagram, přidat trendové čáry k sériím diagramu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Také popisuje, jak do diagramu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátkou časté dotazy (FAQ) o hodnotách projekce trendové čáry dopředu a dozadu a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při vykreslování diagramů jako obrázků.

## **Přidání trendové čáry**
Aspose.Slides for C++ poskytuje jednoduché rozhraní API pro správu různých trendových čar v diagramech:

1. Vytvořte instanci třídy[Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci snímku podle jeho indexu.
1. Přidejte diagram s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá ChartType.ClusteredColumn).
1. Přidání exponenciální trendové čáry pro sérii diagramu 1.
1. Přidání lineární trendové čáry pro sérii diagramu 1.
1. Přidání logaritmické trendové čáry pro sérii diagramu 2.
1. Přidání trendové čáry klouzavého průměru pro sérii diagramu 2.
1. Přidání polynomické trendové čáry pro sérii diagramu 3.
1. Přidání mocninné trendové čáry pro sérii diagramu 3.
1. Zapište upravenou prezentaci do souboru PPTX.

The following code is used to create a chart with Trend Lines.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Přidání vlastní čáry**
Aspose.Slides for C++ poskytuje jednoduché rozhraní API pro přidání vlastních čar do diagramu. Pro přidání jednoduché rovné čáry do vybraného snímku prezentace postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation
- Získejte referenci snímku pomocí jeho Indexu
- Vytvořte nový diagram pomocí metody AddChart, která je součástí objektu Shapes
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **Často kladené otázky**

**Co znamenají 'forward' a 'backward' u trendové čáry?**

Jedná se o délky trendové čáry promítnuté dopředu/dozadu: u rozptylových (XY) diagramů — v jednotkách osy; u jiných diagramů — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane trendová čára zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) a vykresluje diagramy jako obrázky; trendové čáry jako součást diagramu jsou při těchto operacích zachovány. K dispozici je také metoda pro [export obrázku diagramu](/slides/cs/cpp/create-shape-thumbnails/).