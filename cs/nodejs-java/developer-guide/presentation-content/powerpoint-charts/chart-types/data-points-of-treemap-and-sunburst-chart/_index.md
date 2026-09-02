---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst pomocí JavaScriptu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf treemap
- graf sunburst
- hierarchický graf
- datový bod
- datový popisek
- barva větve
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak vytvořit hierarchická data a přizpůsobit úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Grafy Treemap a Sunburst zobrazují stejný typ hierarchických dat, ale používají odlišné rozložení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst ji vykresluje jako koncentrické kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnějším kruhu.

V Aspose.Slides pro Node.js přes Java je každá číselná hodnota typu [ChartDataPoint](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/). Jeho metoda [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Vzor použitý níže má tři úrovně kategorií a jednu číselnou řadu:

| Větev | Střed | List | Tržby |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Každý řádek vytvoří jednu kategorii listu a jeden datový bod. Úrovně seskupení kategorií popisují cestu od tohoto listu k jeho nadřazeným prvkům. Pro první řádek je cesta `Consumer > Computers > Laptops`.

Indexy vrácené metodou [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) probíhají od listu směrem vzhůru:

| `getDataPointLevels()` index | Logická úroveň | Reprezentace Treemap | Reprezentace Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího kruhu |
| `1` | Střed | Obdélník nadřazeného nebo nadpis | Segment prostředního kruhu |
| `2` | Větev | Obdélník nejvyšší úrovně nebo nadpis | Segment vnitřního kruhu |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozložení liší. Nadřazený segment je sdílený několika listy. Pro jeho formátování použijte odpovídající úroveň prvního datového bodu v dané skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco `Software` střed začíná bodem `Licenses`. Uchovávání odkazů na tyto body je přehlednější a bezpečnější než použití nezdokumentovaných výrazů jako `dataPoints.get_Item(0)` nebo `dataPoints.get_Item(6)`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vybuduje hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy na vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Přidejte kategorie listů. Prvek seskupení je nastaven pouze při zahájení nové skupiny;
        // následující kategorie zůstávají v této skupině, dokud není nastaven další prvek.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Zobrazte kategorii a hodnotu na listu Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Naformátujte větev Consumer přes první list v této větvi.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Naformátujte úroveň Software přes první list v této úrovni.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout ovlivňuje nadřazené popisky v Treemap; Sunburst používá segmenty kruhů.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Buňky kategorií a hodnot používají stejný řádek listu, takže jejich pozice v kolekcích zůstávají zarovnané. Když pracujete s existujícím grafem namísto jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované reference na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k vyjádření hodnoty a vnořené obdélníky k vyjádření hierarchie. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) řídí, jak se zobrazují nadřazené popisky v tomto typu grafu.
- Sunburst používá úhel k vyjádření hodnoty a hloubku kruhu k vyjádření hierarchie. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) neovlivňuje popisky jeho kruhů.
- Oba typy grafů používají stejné úrovně seskupení kategorií a stejné pořadí list‑k‑nadřazenému vrácené metodou [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), takže kód pro tvorbu dat a formátování úrovní může být sdílen.
- Hodnoty nadřazených elementů jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo středové úrovně.

### **Řazení a pořadí segmentů**

Engine rozložení grafu určuje konečné umístění obdélníků a segmentů kruhů. Před jejich přidáním uspořádejte související řádky kategorií dohromady, ale nespoléhejte na konkrétní pozici obdélníku nebo počáteční úhel. Pokud má sekvence význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivu prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf sledovat změny motivu, použijte barvy schématu místo pevných hodnot RGB a vyhněte se přepisování každé úrovně. Také po změně výplně větve nebo středu zkontrolujte kontrast popisků.

### **Popisky a dostupný prostor**

PowerPoint může skrýt nebo zkrátit popisky, pokud je segment příliš malý. Zvětšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení menšího počtu polí popisků obvykle vede k přehlednějšímu výsledku. Popisek může kombinovat název kategorie, název řady a hodnotu pomocí [DataLabelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/), ale povolení všech polí často ztíží čtení hierarchických grafů.

### **Export a vykreslování**

Ukládání do PPTX zachovává graf editovatelný. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny s grafem. Náhrada písem a malé rozdíly v dostupném prostoru mohou změnit zalomení řádků nebo viditelnost popisků, proto nainstalujte požadovaná písma a ověřte důležité cíle exportu.

## **Často kladené otázky**

**Proč změna úrovně nadřazeného prvku ovlivní několik listů?**

Větev nebo střed je sdílený vizuální segment. Jeho [ChartDataPointLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapointlevel/) je dostupný přes podřízený list, ale formátování patří sdílenému nadřazenému segmentu, nikoli jen tomuto listu.

**Proč chybí datový popisek?**

Nejprve povolte požadovaná pole na objektu [DataLabelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/) popisku. Pak ověřte, zda má segment dostatek místa. Rozložení popisků rodiče v Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí vše ovlivňuje, zda lze popisek zobrazit.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**

Můžete ovládat pořadí zdrojových řádků a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap ani úhly Sunburst. Engine rozložení grafu je vypočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy změní po změně motivu prezentace?**

Výplně založené na motivu jsou navrženy tak, aby sledovaly paletu prezentace. Použijte explicitní barvy RGB na úrovně, které mají zůstat pevné, nebo zachovejte barvy schématu, pokud je preferována adaptace na nový motiv.

**Zůstane vlastní formátování zachováno při exportu do PDF a obrázků?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty během vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných písem a otestujte finální velikost exportu, protože umístění popisků je závislé na rozložení.

## **Viz také**

- [Vytvořit grafy Treemap](/slides/cs/nodejs-java/create-chart/#creating-tree-map-charts)
- [Vytvořit grafy Sunburst](/slides/cs/nodejs-java/create-chart/#creating-sunburst-charts)
- [Exportovat grafy prezentace](/slides/cs/nodejs-java/export-chart/)
- [Spravovat motivy prezentace](/slides/cs/nodejs-java/presentation-theme/)