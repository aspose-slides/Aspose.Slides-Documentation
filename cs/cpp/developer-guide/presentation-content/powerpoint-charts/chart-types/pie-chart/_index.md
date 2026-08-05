---
title: Přizpůsobení koláčových grafů v prezentacích pomocí C++
linktitle: Koláčový graf
type: docs
url: /cs/cpp/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva segmentu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak v C++ pomocí Aspose.Slides vytvářet a přizpůsobovat koláčové grafy, které lze exportovat do PowerPointu, a během několika sekund zlepšit vyprávění vašich dat."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Popisuje, jak nakonfigurovat možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení segmentů pro standardní koláčový graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení sérií a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides pro C++ nyní podporuje možnosti sekundárního vykreslení pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu si pomocí příkladu ukážeme, jak tyto možnosti nastavit pomocí Aspose.Slides. Pro specifikaci vlastností postupujte podle následujících kroků:

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Přidejte graf na snímek.
1. Specifikujte možnosti sekundárního vykreslení grafu.
1. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili různé vlastnosti grafu Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **Nastavení automatických barev segmentů koláčového grafu**

Aspose.Slides pro C++ poskytuje jednoduché API pro nastavení automatických barev segmentů koláčového grafu. Vzorový kód ukazuje nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy Presentation.
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte název grafu.
1. Nastavte první sérii na Zobrazit hodnoty.
1. Nastavte index listu dat grafu.
1. Získání listu dat grafu.
1. Odstraňte výchozí generované série a kategorie.
1. Přidejte nové kategorie.
1. Přidejte novou sérii.

Uložte upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) sekundární vykreslení pro koláčové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat pouze graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) (např. PNG) bez celé prezentace.