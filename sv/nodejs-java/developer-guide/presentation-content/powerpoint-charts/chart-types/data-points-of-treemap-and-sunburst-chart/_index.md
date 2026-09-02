---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram med JavaScript
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-diagram
- sunburst-diagram
- hierarkiskt diagram
- datapunkt
- datalabel
- grenfärg
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du skapar hierarkisk data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Treemap- och Sunburst-diagram visar samma typ av hierarkisk data, men de använder olika layouter. En Treemap ritar hierarkin som nästlade rektanglar vars områden representerar lövvärden. En Sunburst ritar den som koncentriska ringar: grupper på översta nivån är nära centrum, och lövkategorierna ligger på den yttre ringen.

I Aspose.Slides för Node.js via Java är varje numeriskt värde ett [ChartDataPoint](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/). Dess [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels)-metod ger åtkomst till lövet och dess föräldragrupper. Denna artikel förklarar den mappningen och visar hur man skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap-diagram med Consumer- och Business-grenar](treemap-hierarchy.png)

![Ett Sunburst-diagram med samma Consumer- och Business-hierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Det exempel som används nedan har tre kategorinivåer och en numerisk serie:

| Gren | Stam | Löv | Intäkt |
| --- | --- | --- | ---: |
| Konsument | Datorer | Bärbara | 12 |
| Konsument | Datorer | Stationära | 8 |
| Konsument | Mobil | Telefoner | 15 |
| Konsument | Mobil | Surfplattor | 6 |
| Företag | Tjänster | Konsulttjänster | 10 |
| Företag | Tjänster | Support | 7 |
| Företag | Mjukvara | Licenser | 11 |
| Företag | Mjukvara | Prenumerationer | 14 |

Varje rad skapar en lövkategori och en datapunkt. Kategorigrupperingsnivåerna beskriver vägen från det lövet till dess föräldrar. För den första raden är vägen `Consumer > Computers > Laptops`.

Indexen som returneras av [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) löper från lövet uppåt:

| `getDataPointLevels()` index | Logisk nivå | Treemap-representation | Sunburst-representation |
| ---: | --- | --- | --- |
| `0` | Leaf | Värde-rektangel | Yttre-ringsegment |
| `1` | Stem | Föräldrarektangel eller rubrik | Mellan-ringsegment |
| `2` | Branch | Toppnivårektangel eller rubrik | Inre-ringsegment |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldrasegment delas av flera löv. För att formatera det, använd motsvarande nivå på den första datapunkten i den gruppen. Till exempel startar `Consumer`-grenen med `Laptops`-punkten, medan `Software`-stammen startar med `Licenses`-punkten. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda oförklarade uttryck som `dataPoints.get_Item(0)` eller `dataPoints.get_Item(6)`.

## **Skapa och anpassa båda diagramtyperna**

Följande kompletta exempel skapar ett Treemap på den första bilden och ett Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, applicerar fasta färger på utvalda nivåer, formaterar en grenetikett och sparar presentationen.

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

        // Lägg till lövkategorierna. Ett grupperingselement sätts endast när en ny grupp påbörjas;
        // de följande kategorierna förblir i den gruppen tills ett annat element sätts.
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

        // Visa kategori och värde på Tablets-lövet.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatera Consumer-grenen via det första lövet i den grenen.
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

        // Formatera Software-stammen via det första lövet i den stammen.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout påverkar föräldraetiketterna i Treemap; Sunburst använder ringsegment.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kategoricellerna och värdecellerna använder samma rad i kalkylbladet, så deras samlingspositioner förblir synkroniserade. När du arbetar med ett befintligt diagram istället för att skapa ett, inspektera först kategoriraderna och lagra namngivna referenser till datapunkterna och nivåerna du avser att formatera.

## **Beteende och praktiska överväganden**

### **Treemap- och Sunburst-skillnader**

- Ett Treemap använder yta för att kommunicera värde och nästlade rektanglar för att kommunicera hierarki. Metoden [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) styr hur föräldraetiketter visas i denna diagramtyp.
- Ett Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) kontrollerar inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigrupperingsnivåer och samma löv‑till‑förälder-ordning som returneras av [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), så kod för databyggande och nivåformatering kan delas.
- Föräldravärden beräknas från deras underliggande löv. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagramlayoutmotorn bestämmer den slutgiltiga placeringen av rektanglar och ringsegment. Ordna relaterade kategorirader tillsammans innan du lägger till dem, men förlita dig inte på en specifik rektangelposition eller startvinkel. Om sekvensen har betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategori‑axel.

### **Tema och fasta färger**

Oformaterade diagramnivåer ärver färger från presentationens tema. Exemplet använder explicita RGB‑fyllningar för förutsägbart resultat. Om diagrammet ska följa temaförändringar, använd schemafärger istället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera även etikettkontrasten efter att ha ändrat en gren‑ eller stamfyllning.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagramstorleken, förkorta kategorinamnen eller visa färre etikettfält ger vanligtvis ett tydligare resultat. En etikett kan kombinera kategorinamnet, seriernamnet och värdet via [DataLabelFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/), men att aktivera alla fält gör ofta hierarkiska diagram svåra att läsa.

### **Export och renderering**

Att spara som PPTX behåller diagrammet redigerbart. När Aspose.Slides renderar presentationen till PDF eller en bild, renderas de stödjade fyllningarna och etikettinställningarna med diagrammet. Teckensnittsersättning och små skillnader i tillgängligt layoututrymme kan förändra radbrytning eller etikettens synlighet, så installera de erforderliga teckensnitten och verifiera viktiga exportmål.

## **FAQ**

**Varför påverkar en förändring av en föräldranivå flera löv?**

En gren eller stam är ett delat visuellt segment. Dess [ChartDataPointLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapointlevel/) kan nås via ett underliggande löv, men formateringen tillhör det delade föräldrasegmentet snarare än endast det lövet.

**Varför saknas en datapunktsetikett?**

Aktivera först de erforderliga fälten på etikettens [DataLabelFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/)‑objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldralayout, diagramdimensioner, etikettslängd, teckenstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segmenten?**

Du kan styra källradens ordning och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Diagramlayoutmotorn beräknar dem utifrån hierarkin, värdena och tillgängligt utrymme.

**Varför ändras färgerna när presentations‑temat ändras?**

Färggyfillningar baserade på tema är avsedda att följa presentationens palett. Applicera explicita RGB‑färger på de nivåer som måste förbli fasta, eller behåll schemafärger när anpassning till ett nytt tema föredras.

**Behåller anpassad formatering sig i PDF‑ och bildexport?**

Ja, stödjade diagramfyllningar och etikettinställningar inkluderas under rendering. För konsekventa resultat på tvärs av system, gör de nödvändiga teckensnitten tillgängliga och testa den slutliga exportstorleken eftersom etikettpassning beror på layout.

## **Se också**

- [Skapa Treemap-diagram](/slides/sv/nodejs-java/create-chart/#creating-tree-map-charts)
- [Skapa Sunburst-diagram](/slides/sv/nodejs-java/create-chart/#creating-sunburst-charts)
- [Exportera presentationsdiagram](/slides/sv/nodejs-java/export-chart/)
- [Hantera presentationsteman](/slides/sv/nodejs-java/presentation-theme/)