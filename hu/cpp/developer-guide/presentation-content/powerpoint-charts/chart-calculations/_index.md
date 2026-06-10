---
title: Diagram számítások optimalizálása bemutatókhoz C++-ban
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/cpp/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíció
- valódi pozíció
- gyermek elem
- szülő elem
- diagram értékek
- valódi érték
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Értse meg a diagram számításokat, az adatfrissítéseket és a pontosság szabályozását az Aspose.Slides for C++-ban PPT és PPTX esetén, gyakorlati C++ kódpéldákkal."
---
## **Áttekintés**

Az Aspose.Slides API-kat biztosít diagramok számításához és elrendezési adatokhoz a bemutatókban. Ez a cikk bemutatja, hogyan lehet lekérni a diagramelemek tényleges értékeit, beleértve a `IActualLayout`‑et megvalósító elemek valódi pozícióját és méretét, valamint a diagram tengelyeinek tényleges értékeit. Az is kiderül, hogy ezek az értékek a diagramelrendezés ellenőrzése után töltődnek fel.

Továbbá a cikk bemutatja, hogyan lehet lekérni a szülő diagramelemek tényleges pozícióját, és hogyan lehet elrejteni a diagram összetevőit, mint a cím, tengelyek, jelmagyarázat és rácsvonalak. Ezek az példák segítenek a diagramelrendezési információk vizsgálatában és a diagramelemek láthatóságának programozott vezérlésében a PowerPoint bemutatókban.

## **Diagramelemek tényleges értékeinek kiszámítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. Ez segít a diagramelemek tényleges értékeinek kiszámításában. A tényleges értékek tartalmazzák a IActualLayout interfészt megvalósító elemek pozícióját (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) és a tényleges tengelyértékeket (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Prezentáció mentése
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **A szülő diagramelemek tényleges pozíciójának kiszámítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. Az IActualLayout metódusai információt adnak a szülő diagramelem tényleges pozíciójáról. A tulajdonságok tényleges értékekkel való feltöltéséhez előzetesen meg kell hívni az IChart::ValidateChartLayout() metódust.

``` cpp
// Üres bemutató létrehozása
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Diagramelemek elrejtése**
Ez a téma segít megérteni, hogyan lehet információkat elrejteni a diagramról. Az Aspose.Slides for C++ használatával elrejtheti a **Címet, Függőleges tengelyt, Vízszintes tengelyt** és a **Rácsvonalakat** a diagramról. Az alábbi kódrészlet bemutatja, hogyan kell használni ezeket a tulajdonságokat.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Adattartomány beállítása egy diagramhoz**
Az Aspose.Slides for C++ a legegyszerűbb API-t biztosítja a diagram adattartományának beállításához a legegyszerűbb módon. Az adattartomány beállításához:

- Nyisson meg egy Presentation osztály példányt, amely diagramot tartalmaz.
- Szerezze meg egy dia referenciáját annak Indexe alapján.
- Járja be az összes alakzatot a kívánt diagram megtalálásához.
- Hozza elérhetővé a diagram adatait és állítsa be a tartományt.
- Mentse a módosított bemutatót PPTX fájlként.

Az alábbi kódrészletek bemutatják, hogyan frissíthető a diagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **GYIK**

**Működnek a külső Excel munkafüzetek adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. A diagram hivatkozhat egy külső munkafüzetre: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek azt a munkafüzetet veszik, és a diagram a nyitás/szerkesztés során frissül. Az API lehetővé teszi, hogy [adja meg a külső munkafüzetet](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) útvonalát és kezelje a kapcsolt adatokat.

**Képes vagyok trendvonalakat számolni és megjeleníteni anélkül, hogy magam implementálnám a regressziót?**

Igen. [Trendvonalak](/slides/hu/cpp/trend-line/) (lineáris, exponenciális és egyéb) automatikusan hozzáadódnak és frissülnek az Aspose.Slides által; paramétereiket a sorozat adataiból számítja újra, így nem szükséges saját számításokat írni.

**Ha egy bemutató több diagramot tartalmaz külső hivatkozásokkal, szabályozhatom, hogy melyik munkafüzetet használja minden diagram a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzetre](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) hivatkozhat, vagy függetlenül létrehozhat/lecserélhet egy külső munkafüzetet diagramonként.