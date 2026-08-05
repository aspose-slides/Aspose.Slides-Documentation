---
title: Přizpůsobení oblastí vykreslování grafů v prezentacích v C++
linktitle: Oblast vykreslování
type: docs
url: /cs/cpp/chart-plot-area/
keywords:
- graf
- oblast vykreslování
- šířka oblasti vykreslování
- výška oblasti vykreslování
- velikost oblasti vykreslování
- režim rozvržení
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslování grafů v prezentacích PowerPoint pomocí Aspose.Slides pro C++. Zlepšete vizuální stránku svých snímků s lehkostí."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslování grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslování ověřením rozvržení grafu a následným čtením hodnot X, Y, šířky a výšky.

Také demonstruje, jak nastavit režim rozvržení oblasti vykreslování, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType` k definování, zda je oblast vykreslování počítána podle vnitřní oblasti nebo podle vnější oblasti spolu s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslování grafu**
Aspose.Slides for C++ poskytuje jednoduché rozhraní API.

1. Vytvořte instanci třídy[Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Přístup k první snímku.
1. Přidejte graf s výchozími daty.
1. Před získáním skutečných hodnot zavolejte metodu IChart::ValidateChartLayout().
1. Získá skutečnou X polohu (levý okraj) prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečnou horní polohu prvku grafu relativně k levému hornímu rohu grafu.
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


## **Nastavení režimu rozvržení oblasti vykreslování grafu**
Aspose.Slides for C++ poskytuje jednoduché rozhraní API pro nastavení režimu rozvržení oblasti vykreslování grafu. Vlastnost **LayoutTargetType** byla přidána do tříd **ChartPlotArea** a **IChartPlotArea**. Pokud je rozvržení oblasti vykreslování definováno ručně, tato vlastnost určuje, zda má být oblast vykreslování uspořádána podle vnitřku (bez os a popisků os) nebo podle vnějšího okraje (včetně os a popisků os). Existují dvě možné hodnoty, které jsou definovány v enumeraci **LayoutTargetType**.

- **LayoutTargetType.Inner** – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, aniž by zahrnovala značky os a popisky os.
- **LayoutTargetType.Outer** – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, značky os a popisky os.

Ukázkový kód je uveden níže.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny ActualX, ActualY, ActualWidth a ActualHeight?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslování liší od oblasti grafu z hlediska obsahu?**

Oblast vykreslování je oblast pro kreslení dat (série, mřížky, trendové čáry atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). U 3D grafů oblast vykreslování také zahrnuje stěny/podlahu a osy.

**Jak jsou interpretovány X, Y, Width a Height oblasti vykreslování, když je rozvržení nastaveno ručně?**

Jedná se o zlomky (0‑1) celkové velikosti grafu; v tomto režimu je automatické umisťování vypnuto a použijí se zlomky, které jste nastavili.

**Proč se změnila poloha oblasti vykreslování po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslování, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslování se může posunout, když je aktivní automatické umisťování. (Jedná se o standardní chování grafů v PowerPointu.)