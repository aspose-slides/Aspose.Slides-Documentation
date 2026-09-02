---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v Javě
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf Treemap
- graf Sunburst
- hierarchický graf
- datový bod
- popisek dat
- barva větve
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak vytvořit hierarchická data a přizpůsobit úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro Java."
---
## **Přehled**

Grafy Treemap a Sunburst zobrazují stejný typ hierarchických dat, ale používají odlišné rozložení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst ji vykresluje jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a kategorie listů jsou na vnějším kruhu.

V Aspose.Slides for Java je každá číselná hodnota typu [IChartDataPoint](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/). Jeho metoda [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Porozumění kategoriím, datovým bodům a úrovním**

Ukázka použitá níže má tři úrovně kategorií a jednu číselnou řadu:

| Větev | Kmen | List | Výnos |
| --- | --- | --- | ---: |
| Spotřebitel | Počítače | Notebooky | 12 |
| Spotřebitel | Počítače | Stolní počítače | 8 |
| Spotřebitel | Mobilní | Telefony | 15 |
| Spotřebitel | Mobilní | Tablety | 6 |
| Podnik | Služby | Konzultace | 10 |
| Podnik | Služby | Podpora | 7 |
| Podnik | Software | Licence | 11 |
| Podnik | Software | Předplatná | 14 |

Každý řádek vytváří jednu kategorii listu a jeden datový bod. Úrovně seskupování kategorií popisují cestu od tohoto listu k jeho nadřazeným. Pro první řádek je cesta `Spotřebitel > Počítače > Notebooky`.

Indexy vrácené metodou [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) běží od listu směrem nahoru:

| Index `getDataPointLevels()` | Logická úroveň | Reprezentace Treemap | Reprezentace Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího prstence |
| `1` | Kmen | Obdélník nadřazeného nebo záhlaví | Segment prostředního prstence |
| `2` | Větev | Obdélník nejvyšší úrovně nebo záhlaví | Segment vnitřního prstence |

Toto pořadí je stejné pro oba typy grafů, i když se jejich vizuální rozložení liší. Nadřazený segment je sdílený několika listy. Pro formátování použijte odpovídající úroveň prvního datového bodu v dané skupině. Například větev `Spotřebitel` začíná bodem `Notebooky`, zatímco kmen `Software` začíná bodem `Licence`. Udržování odkazů na tyto body je přehlednější a bezpečnější než používání nevysvětlených výrazů jako `dataPoints.get_Item(0)` nebo `dataPoints.get_Item(6)`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablety`, použije pevné barvy na vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

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

        // Přidejte kategorie listů. Prvek seskupení je nastaven pouze při zahájení nové skupiny;
        // následující kategorie zůstávají v této skupině, dokud není nastaven další prvek.
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

        // Zobrazte kategorii a hodnotu u listu Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formátujte větev Consumer prostřednictvím prvního listu v této větvi.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formátujte kmen Software prostřednictvím prvního listu v tomto kmenu.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout ovlivňuje popisky nadřazených prvků v Treemap; Sunburst používá segmenty prstenců.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Buňky kategorií a buňky hodnot používají stejný řádek pracovního listu, takže jejich pozice ve sbírce zůstávají zarovnané. Když pracujete s existujícím grafem místo jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k vyjádření hodnoty a vnořené obdélníky k vyjádření hierarchie. Metoda [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) určuje, jak se zobrazují popisky nadřazených prvků v tomto typu grafu.
- Sunburst používá úhel k vyjádření hodnoty a hloubku prstence k vyjádření hierarchie. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) neovlivňuje popisky prstenců.
- Oba typy grafů používají stejné úrovně seskupování kategorií a stejné pořadí list‑k‑nadřazenému vrácené metodou [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), takže kód pro tvorbu dat a formátování úrovní může být sdílen.
- Hodnoty nadřazených prvků jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo kmeny.

### **Řazení a pořadí segmentů**

Engine rozložení grafu určuje konečné umístění obdélníků a segmentů prstenců. Seskupte související řádky kategorií před jejich přidáním, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud sekvence nese význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivu prezentace. Příklad používá explicitní RGB výplně pro předvídatelný výstup. Pokud má graf sledovat změny motivu, použijte barvy ze schématu místo pevných RGB hodnot a vyhněte se přepisování každé úrovně. Také zkontrolujte kontrast popisků po změně výplně větve nebo kmene.

### **Popisky a dostupný prostor**

PowerPoint může skrývat nebo zkracovat popisky, když je segment příliš malý. Zvýšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení méně polí popisků obvykle vede k přehlednějšímu výsledku. Popisek může kombinovat název kategorie, název řady a hodnotu pomocí [IDataLabelFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatalabelformat/), ale povolení všech polí často ztíží čitelnost hierarchických grafů.

### **Export a vykreslování**

Ukládání do PPTX zachovává editovatelnost grafu. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny s grafem. Substituce fontů a malé rozdíly v dostupném prostoru mohou změnit zalomení řádků nebo viditelnost popisků, proto nainstalujte požadované fonty a ověřte důležitá exportní cíle.

## **Často kladené otázky**

**Proč změna úrovně nadřazeného prvku ovlivní několik listů?**

Větev nebo kmen je sdílený vizuální segment. Jeho [IChartDataPointLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatapointlevel/) lze dosáhnout přes podřízený list, ale formátování patří sdílenému nadřazenému segmentu, nikoli pouze tomuto listu.

**Proč chybí datová popiska?**

Nejprve povolte požadovaná pole na objektu [IDataLabelFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatalabelformat/) popisku. Pak zkontrolujte, zda má segment dostatek místa. Rozložení popisků nadřazených prvků Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí všechny ovlivňují, zda může být popisek zobrazen.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**

Můžete ovládat pořadí zdrojových řádků a udržet každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap nebo úhly Sunburst. Engine rozložení grafu je vypočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy mění po změně motivu prezentace?**

Výplně založené na motivu jsou navrženy tak, aby sledovaly paletu prezentace. Použijte explicitní RGB barvy pro úrovně, které musí zůstat pevné, nebo ponechte barvy ze schématu, pokud je preferováno přizpůsobení novému motivu.

**Zůstane vlastní formátování zachováno při exportu do PDF a obrázků?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty během vykreslování. Pro konzistentní výsledky napříč systémy zajistěte dostupnost požadovaných fontů a otestujte konečnou velikost exportu, protože umístění popisků je závislé na rozložení.

## **Viz také**

- [Create Treemap charts](/slides/cs/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/cs/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/cs/java/export-chart/)
- [Manage presentation themes](/slides/cs/java/presentation-theme/)