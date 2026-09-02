---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst na Androidu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf Treemap
- graf Sunburst
- hierarchický graf
- datový bod
- datový popisek
- barva větve
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se vytvářet hierarchická data a přizpůsobovat úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro Android via Java."
---
## **Přehled**

Grafy typu Treemap a Sunburst zobrazují stejný druh hierarchických dat, ale používají odlišné rozvržení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst ji vykresluje jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnějším kruhu.

V Aspose.Slides pro Android via Java je každá číselná hodnota **[IChartDataPoint](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/)**. Jeho metoda **[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)** poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Níže uvedený příklad obsahuje tři úrovně kategorií a jeden číselný řad:

| Větev | Střed | List | Obrat |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Každý řádek vytvoří jednu kategorii listu a jeden datový bod. Úrovně seskupení kategorií popisují cestu od tohoto listu k jeho nadřazeným položkám. Pro první řádek je cesta `Consumer > Computers > Laptops`.

Indexy vrácené metodou **[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)** probíhají od listu směrem vzhůru:

| `getDataPointLevels()` index | Logická úroveň | Zobrazení Treemap | Zobrazení Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího kruhu |
| `1` | Střed | Obdélník nebo záhlaví rodiče | Segment prostředního kruhu |
| `2` | Větev | Obdélník nebo záhlaví nejvyšší úrovně | Segment vnitřního kruhu |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozvržení liší. Segment rodiče je sdílen několika listy. Pro jeho formátování použijte odpovídající úroveň prvního datového bodu v dané skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco střed `Software` začíná bodem `Licenses`. Uchovávání odkazů na tyto body je přehlednější a bezpečnější než používání nevysvětlených výrazů jako `dataPoints.get_Item(0)` nebo `dataPoints.get_Item(6)`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy na vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Přidejte kategorie listů. Prvek seskupení se nastaví pouze při zahájení nové skupiny;
        // následující kategorie zůstávají v této skupině, dokud není nastaven jiný prvek.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Zobrazte kategorii a hodnotu na listu Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Naformátujte větev Consumer pomocí prvního listu v této větvi.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Naformátujte větev Software pomocí prvního listu v této větvi.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout ovlivňuje popisky rodičů v Treemap; Sunburst používá segmenty kruhů.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Buňky kategorií a buňky hodnot používají stejný řádek listu, takže jejich pozice ve sbírce zůstávají zarovnané. Pokud pracujete s existujícím grafem místo jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k vyjádření hodnoty a vnořené obdélníky k vyjádření hierarchie. Metoda **[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)** řídí, jak se zobrazují popisky rodičů v tomto typu grafu.
- Sunburst používá úhel k vyjádření hodnoty a hloubku kruhu k vyjádření hierarchie. **[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)** neovlivňuje popisky jeho kruhů.
- Oba typy grafů používají stejné úrovně seskupení kategorií a stejné pořadí list‑k‑rodiči vrácené metodou **[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)**, takže kód pro sestavování dat a formátování úrovní může být sdílen.
- Hodnoty rodičů se vypočítávají z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo středové úrovně.

### **Řazení a pořadí segmentů**

Engine rozvržení grafu určuje konečné umístění obdélníků a segmentů kruhů. Před jejich přidáním seskupte související řádky kategorií, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud má sekvence význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivu prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf následovat změny motivu, použijte barvy schématu místo pevných hodnot RGB a vyhněte se přepisování každé úrovně. Také po změně výplně větve nebo středu zkontrolujte kontrast popisků.

### **Popisky a dostupný prostor**

PowerPoint může skrýt nebo zkrátit popisky, pokud je segment příliš malý. Zvětšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení méně polí popisku obvykle vede k jasnějšímu výsledku. Popisek může kombinovat název kategorie, název řady a hodnotu pomocí **[IDataLabelFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatalabelformat/)**, ale povolení všech polí často ztěžuje čtení hierarchických grafů.

### **Export a vykreslování**

Ukládání do PPTX zachovává graf editovatelný. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny s grafem. Substituce písem a malé rozdíly v dostupném prostoru rozvržení mohou změnit zalomení řádků nebo viditelnost popisků, proto nainstalujte požadovaná písma a ověřte důležité cíle exportu.

## **Často kladené otázky**

**Proč změna úrovně rodiče ovlivní několik listů?**

Větev nebo střed je sdílený vizuální segment. K jeho **[IChartDataPointLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatapointlevel/)** lze přistupovat přes podřízený list, ale formátování patří sdílenému segmentu rodiče, nikoli jen danému listu.

**Proč chybí datový popisek?**

Nejprve povolte požadovaná pole na objektu **[IDataLabelFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idatalabelformat/)** popisku. Poté zkontrolujte, zda má segment dostatek místa. Rozvržení popisků rodičů u Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí vše ovlivňuje, zda může být popisek zobrazen.

**Mohu nastavit přesné pořadí či souřadnice segmentů?**

Můžete řídit pořadí řádků zdroje a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap ani úhly Sunburst. Engine rozvržení grafu je vypočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy změní po změně motivu prezentace?**

Výplně založené na motivu jsou navrženy tak, aby sledovaly paletu prezentace. Použijte explicitní barvy RGB pro úrovně, které musí zůstat pevné, nebo při upřednostňování přizpůsobení novému motivu zachovejte barvy schématu.

**Zůstane vlastní formátování zachováno v exportech PDF a obrázků?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty během vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných písem a otestujte konečnou velikost exportu, protože umístění popisků je závislé na rozvržení.

## **Související odkazy**

- [Create Treemap charts](/slides/cs/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/cs/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/cs/androidjava/export-chart/)
- [Manage presentation themes](/slides/cs/androidjava/presentation-theme/)