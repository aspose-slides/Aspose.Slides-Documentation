---
title: Přizpůsobení koláčových diagramů v prezentacích pomocí C++
linktitle: Koláčový diagram
type: docs
url: /cs/cpp/pie-chart/
keywords:
- koláčový diagram
- správa diagramu
- přizpůsobení diagramu
- možnosti diagramu
- nastavení diagramu
- možnosti vykreslení
- barva segmentu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak vytvářet a přizpůsobovat koláčové diagramy v C++ pomocí Aspose.Slides, exportovatelné do PowerPointu, a tím během několika sekund oživení prezentace vašich dat."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými diagramy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního grafu pro diagramy Pie of Pie a Bar of Pie a jak povolit automatické barevné označování segmentů standardního koláčového diagramu.

Příklady se zaměřují na praktické kroky přizpůsobení diagramu, jako je přidání diagramu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat diagramu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního grafu pro diagramy Pie of Pie a Bar of Pie**

Aspose.Slides pro C++ nyní podporuje možnosti sekundárního grafu pro diagramy Pie of Pie nebo Bar of Pie. V tomto tématu si pomocí příkladu ukážeme, jak tyto možnosti specifikovat pomocí Aspose.Slides. Pro nastavení vlastností postupujte podle níže uvedených kroků:

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Přidejte diagram na snímek.
3. Zadejte možnosti sekundárního grafu diagramu.
4. Zapište prezentaci na disk.

V níže uvedeném příkladu jsme nastavili různé vlastnosti diagramu Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Nastavení automatických barev segmentů koláčového diagramu**

Aspose.Slides pro C++ poskytuje jednoduché rozhraní API pro nastavení automatických barev segmentů koláčového diagramu. Ukázkový kód aplikuje nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy Presentation.
2. Získejte první snímek.
3. Přidejte diagram s výchozími daty.
4. Nastavte název diagramu.
5. Nastavte první řadu na Zobrazit hodnoty.
6. Nastavte index listu dat diagramu.
7. Získání pracovního listu dat diagramu.
8. Odstraňte výchozí generované řady a kategorie.
9. Přidejte nové kategorie.
10. Přidejte nové řady.

Uložte upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) sekundární graf pro koláčové diagramy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat pouze diagram jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný diagram jako obrázek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) (např. PNG) bez celé prezentace.