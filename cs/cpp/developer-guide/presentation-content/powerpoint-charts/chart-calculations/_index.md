---
title: Optimalizace výpočtů grafů pro prezentace v C++
linktitle: Výpočty grafu
type: docs
weight: 50
url: /cs/cpp/chart-calculations/
keywords:
- výpočty grafu
- prvky grafu
- pozice prvku
- skutečná pozice
- podřízený prvek
- nadřazený prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro C++ pro PPT a PPTX, s praktickými ukázkami kódu v C++."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a daty rozložení v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků, které implementují `IActualLayout`, a skutečné hodnoty os grafu. Také vysvětluje, že tyto hodnoty jsou vyplněny po ověření rozložení grafu.

Kromě toho článek ukazuje, jak získat skutečnou polohu nadřazených prvků grafu a jak skrýt komponenty grafu, jako jsou název, osy, legenda a mřížkové čáry. Společně tyto příklady pomáhají kontrolovat informace o rozložení grafu a programově řídit viditelnost prvků grafu v prezentacích PowerPoint.

## **Vypočítat skutečné hodnoty prvků grafu**
Aspose.Slides for C++ poskytuje jednoduché API pro získání těchto vlastností. To vám pomůže vypočítat skutečné hodnoty prvků grafu. Skutečné hodnoty zahrnují polohu prvků, které implementují rozhraní IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) a skutečné hodnoty os (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Ukládání prezentace
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Vypočítat skutečnou polohu nadřazených prvků grafu**
Aspose.Slides for C++ poskytuje jednoduché API pro získání těchto vlastností. Metody IActualLayout poskytují informace o skutečné poloze nadřazeného prvku grafu. Je nutné předem zavolat metodu IChart::ValidateChartLayout(), aby se vlastnosti naplnily skutečnými hodnotami.

``` cpp
// Vytvoření prázdné prezentace
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Skrýt prvky grafu**
Tato téma vám pomůže pochopit, jak skrýt informace v grafu. Pomocí Aspose.Slides for C++ můžete skrýt **Název, svislou osu, vodorovnou osu** a **Mřížkové čáry** v grafu. Níže uvedený příklad kódu ukazuje, jak tyto vlastnosti použít.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Nastavit datový rozsah pro graf**
Aspose.Slides for C++ poskytuje nejjednodušší API pro nastavení datového rozsahu grafu co nejjednodušším způsobem. Pro nastavení datového rozsahu grafu:

- Otevřete instanci třídy Presentation obsahující graf.
- Získejte odkaz na snímek pomocí jeho Indexu.
- Projděte všechny tvary a najděte požadovaný graf.
- Přistupte k datům grafu a nastavte rozsah.
- Uložte upravenou prezentaci jako soubor PPTX.

Následující ukázky kódu ukazují, jak aktualizovat graf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **Často kladené otázky**

**Fungují externí sešity Excelu jako zdroj dat a jak to ovlivňuje přepočet?**

Ano. Graf může odkazovat na externí sešit: když připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf odráží aktualizace během operací otevření/úpravy. API vám umožní [specifikovat externí sešit](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) cestu a spravovat propojená data.

**Mohu vypočítat a zobrazit čáry trendu bez implementace regrese sami?**

Ano. [Čáry trendu](/slides/cs/cpp/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány pomocí Aspose.Slides; jejich parametry jsou automaticky přepočítány z dat řady, takže není nutné implementovat vlastní výpočty.

**Pokud má prezentace několik grafů s externími odkazy, mohu ovládat, který sešit každý graf používá pro vypočítané hodnoty?**

Ano. Každý graf může odkazovat na svůj vlastní [externí sešit](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), nebo můžete pro každý graf vytvořit/nahradit externí sešit nezávisle na ostatních.