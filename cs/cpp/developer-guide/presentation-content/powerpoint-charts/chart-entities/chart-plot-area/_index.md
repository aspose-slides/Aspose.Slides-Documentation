---
title: Přizpůsobení oblastí vykreslování grafů v prezentacích v С++
linktitle: Oblast vykreslování
type: docs
url: /cs/cpp/chart-plot-area/
keywords:
- graf
- oblast vykreslování
- šířka oblasti vykreslování
- výška oblasti vykreslování
- velikost oblasti vykreslování
- režim rozložení
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslování grafů v prezentacích PowerPoint pomocí Aspose.Slides pro С++. Vylepšete vizuály snímků snadno."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslování grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslování ověřením rozložení grafu a následným čtením hodnot X, Y, šířky a výšky.

Také demonstruje, jak nastavit režim rozložení oblasti vykreslování, když je rozložení nastaveno ručně, pomocí `LayoutTargetType` k určení, zda je oblast vykreslování vypočítána podle svého vnitřního regionu nebo podle vnějšího regionu společně s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslování grafu**
Aspose.Slides for C++ poskytuje jednoduché API pro .

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Zavolejte metodu IChart::ValidateChartLayout() předtím, abyste získali skutečné hodnoty.
1. Získá skutečnou X polohu (levý) prvku grafu vzhledem k levému hornímu rohu grafu.
1. Získá skutečnou horní polohu prvku grafu vzhledem k levému hornímu rohu grafu.
1. Získá skutečnou šířku prvku grafu.
1. Získá skutečnou výšku prvku grafu.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Uložit prezentaci s grafem
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Nastavení režimu rozložení oblasti vykreslování grafu**
Aspose.Slides for C++ poskytuje jednoduché API pro nastavení režimu rozložení oblasti vykreslování grafu. Vlastnost **LayoutTargetType** byla přidána do tříd **ChartPlotArea** a **IChartPlotArea**. Pokud je rozložení oblasti vykreslování definováno ručně, tato vlastnost určuje, zda rozložit oblast vykreslování podle jejího vnitřku (bez os a popisků os) nebo podle vnějšího okraje (včetně os a popisků os). Existují dvě možná hodnoty, které jsou definovány v enumeraci **LayoutTargetType**.

- **LayoutTargetType.Inner** – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, bez značek a popisků os.
- **LayoutTargetType.Outer** – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, značky a popisky os.

Ukázkový kód je uveden níže.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**V jakých jednotkách jsou vráceny ActualX, ActualY, ActualWidth a ActualHeight?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslování (Plot Area) liší od oblasti grafu (Chart Area) co se týče obsahu?**

Oblast vykreslování je oblast pro kreslení dat (řady, mřížky, čáry trendů atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). Ve 3D grafech oblast vykreslování také zahrnuje stěny/podlahu a osy.

**Jak jsou X, Y, Width a Height oblasti vykreslování interpretovány při ručním rozložení?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umístění zakázáno a použijí se nastavené zlomky.

**Proč se pozice oblasti vykreslování změnila po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslování, ale ovlivňuje rozložení a dostupný prostor, takže oblast vykreslování se může posunout, pokud je zapnuto automatické umístění. (Jedná se o standardní chování grafů v PowerPointu.)